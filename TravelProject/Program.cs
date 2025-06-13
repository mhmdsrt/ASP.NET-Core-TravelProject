using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TravelProject.CQRS.Handlers.DestinationHandlers;
using TravelProject.Models;
using TravelProject.ValidationRules;

var builder = WebApplication.CreateBuilder(args);

/*
 Identity sistemini eklerken kullan�c� tipi olarak "AppUser", rol tipi olarak da "AppRole" kullanaca��m ve kullan�c�/rol bilgilerini
 "Context" �zerinde saklayaca��m anlam�na geliyor. Yani EF kullanarak bu bilgileri Context s�n�f� ile veritaban�na yaz.

 A�a��daki yap� Identity sisteminde kullan�lacak t�m servislerin (UserManager<AppUser>, RoleManager<AppRole>, SignInManager<AppUser> vb.) Contructor'�na 
 AppUser'� ve AppRole'u y�netek servisleri yani "UserManager<AppUser>" gibi servisleri enjekte eder.(Dependecy Injection)

"AddErrorDescriber<CustomIdentityValidator>()" ile Identity sistemine bizim �zel tan�mlad���m�z "CustomIdentityValidator" class�n�
kullanmas�n� s�yler
 */
builder.Services.AddIdentity<AppUser, AppRole>()
.AddEntityFrameworkStores<Context>()
	.AddErrorDescriber<CustomIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);


// DI sistemine kaydediyoruz. DestinationCQRSController taraf�ndan Constructor i�erisinde bekkliyor
builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationByIdQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<RemoveDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();


// Authorization -> Yetkikendirme, Policy -> Politika ,Authenticated -> Kimli�i Do�rulanm��, Require -> Gerekli K�lmak
//  Politika -> t�rk�ede kurallar koymak ve uygulamak i�in yap�lan faaliyetler demektir.
builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder() // AuthorizationPolicyBuilder -> Yetkilendirme Politika Olu�turucusu
	.RequireAuthenticatedUser() // RequireAuthenticatedUser->Kimli�i Do�rulanm�� Kull�c�y� Gerekli K�l
	.Build(); // Build -> Olu�tur.

	config.Filters.Add(new AuthorizeFilter(policy));

	// Authorize -> Yetki vermek.
	// Bu yap� sayesinden t�m MVC hizmetlerine Yetkilendiri�mi� ki�i taraf�ndan giri� yapmay� zorunlu k�l�yoruz.(Proje Seviyesinde)
	// Yani gidip tek tek [Authorize] yazmam�za gerek kalm�yor. Projenin geneline [Authorize] uyguluyor.
});



/*
 Bu projede tan�mlanm�� t�m AutoMapper Frameworkundeki Profil s�n�f�ndan miras alan classlar� bul ve CreateMap<> kurallar�n� kaydet
Di�er g�revi ise IMapper mapper isteyen yerlerden DI sistemi ile  mapper nesnesini enjekte etmesi.
Yani di�er bir deyi�le IMapper DI sistemine eklenir.Yani aray�zlerin nesne �rneklerinin Dependency Injection sistemiyle olu�turulur.
 */
builder.Services.AddAutoMapper(typeof(Program));


/*
 Bu projede tan�mlanm�� t�m IRequest, IRequestHandler, INotification, INotificationHandler gibi MediatR bile�enleini bul,
ve DI Container'a kaydet.Yani aray�zlerin nesne �rneklerinin Dependency Injection sistemiyle olu�turulur.
 */
builder.Services.AddMediatR(typeof(Program));




// Bu sat�r DI'ya t�m validatorlar� tek kod sat�r� ile ekler:
builder.Services.AddValidatorsFromAssemblyContaining<DestinationValidator>(); // Controller taraf�nda new'lemekten kurtulup DI ile enjekte ediyoruz
/*
  "DestinationValidator hangi assembly'deyse, o assembly'deki t�m AbstractValidator<T> s�n�flar�n� tara ve IValidator<T> olarak 
   DI sistemine ekle."
Yani yukar�daki tek sat�rl�k kod sayesinde a�a��daki gibi tek tek yazmam�za gerek kalmad� t�m Validator s�n�flar�m�z� bulup otomatik DI yap�cak
"builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();"
"builder.Services.AddScoped<IValidator<Reservation>, ReservationValidator>();" 

yani di�er t�m contoller i�erisindeki Constructor metodunda farkl� tipteki IValidayor<Category> gibi 
do�rulay�c� istendi�inde bu tek sat�rl�k kod sayesinde otomatik olarak DI yap�lacak
 */





/*
  "builder.Services.AddDbContext<Context>" ifadesi Context nesnesini DI(Dependecy Injection) Sistemine kaydeder.
   B�ylece, Context nesnesi t�m repository s�n�flar�nda tek bir �rnek (instance) �zerinden �al���r.
   Context s�n�f� tipinde nesneye ihtiya� duyulan heryerde enjeckte edilir. 
 */
builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // appsettings.json dosyas�ndaki "DefaultConnection" ba�lant� dizesini al�yoruz.



/*
  Dependecy Injection yap�s� sayesinde IAboutRepository isteyen her yere AboutRepository nesnesini otomatik olarak enjekte edicek(vericek).
 
 "AddScoped" ile her HTTP iste�i i�in yeni bir nesne olu�turur ve ayn� istekde tekrar kullan�l�r,
  Daha sonra istek bitti�inde DbContext kapat�l�r ve bellek temizlenir.

  Veritaban� ba�lant�lar� a��r i�lemlerdir. Bir iste�e �zel ba�lant� a��p geri kapatmal�y�z Scope da tam bunu yapar.

 AddScoped -> Her HTTP iste�i i�in yeni bir nesne olu�turup ayn� istekde tekrar kullan�r
 AddTransient -> Her �a�r�ld���nda yeni bir nesne olu�turur. Hafif ve k�sa s�reli i�lemlere uygundur. �rne�in : EmailService, SMSService gibi k�sa s�reli i�lemler.
 AddSingleton -> Uygulama boyunca ayn� nesneyi kullan�r. Statik (de�i�meyen) servisler i�in uygundur. �rne�in : CacheService, LoggingService, ConfigurationService gibi de�i�meyen hizmetler.
 */
builder.Services.AddScoped<IAbout2Service, About2Service>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IDestinationService, DestinationService>();
builder.Services.AddScoped<IFeature2Service, Feature2Service>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IGuideService, GuideService>();
builder.Services.AddScoped<INewsletterService, NewsletterService>();
builder.Services.AddScoped<ISubAboutService, SubAboutService>();
builder.Services.AddScoped<ITestimonialService, TestimonialService>();
builder.Services.AddScoped<ICommentService, CommentService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<IAppUserService, AppUserService>();
builder.Services.AddScoped<IContactUsService, ContactUsService>();
builder.Services.AddScoped<IAnnouncementService, AnnouncementService>();
builder.Services.AddScoped<IAppRoleService, AppRoleService>();
builder.Services.AddScoped<IAppUserService, AppUserService>();



builder.Services.AddScoped<IAboutRepository, AboutRepository>();
builder.Services.AddScoped<IAbout2Repository, About2Repository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IDestinationRepository, DestinationRepository>();
builder.Services.AddScoped<IFeature2Repository, Feature2Repository>();
builder.Services.AddScoped<IFeatureRepository, FeatureRepository>();
builder.Services.AddScoped<IGuideRepository, GuideRepository>();
builder.Services.AddScoped<INewsletterRepository, NewsletterRepository>();
builder.Services.AddScoped<ISubAboutRepository, SubAboutRepository>();
builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
builder.Services.AddScoped<ICommentRepository, CommentRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<IContactUsRepository, ContactUsRepository>();
builder.Services.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
builder.Services.AddScoped<IAppRoleRepository, AppRoleRepository>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Home/Error");
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/ErrorPage/Error", "?code={0}"); // ErrorPage
/*
  Bir hata olu�tu�u zaman ErrorPage Controller alt�ndaki Error Action'u �al��t�racak.
  Ayr�ca olu�an hatan�n kodu "0" yazan yere yaz�lacak. B�ylece ErrorPage controller i�erisindeki
  Error(int code) ile actionuna hangi durumla ilgili hata olu�tuysa Error(int code) i�idenki "code"
  de�erine o hata kodu yaz�l�r.

 Yani hangi durumla ile ilgili hata kodu olu�ursa ErrorPage Controller'�n alt�ndaki Error metoduna o hata kodunu
 Error metoduna parametre olarak g�nderilir.
 
 */

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

 app.MapControllerRoute( 
     name : "areas",
     pattern : "{area:exists}/{controller=Home}/{action=Index}/{id?}");


app.Run();
