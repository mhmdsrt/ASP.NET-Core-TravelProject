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
 Identity sistemini eklerken kullanýcý tipi olarak "AppUser", rol tipi olarak da "AppRole" kullanacaðým ve kullanýcý/rol bilgilerini
 "Context" üzerinde saklayacaðým anlamýna geliyor. Yani EF kullanarak bu bilgileri Context sýnýfý ile veritabanýna yaz.

 Aþaðýdaki yapý Identity sisteminde kullanýlacak tüm servislerin (UserManager<AppUser>, RoleManager<AppRole>, SignInManager<AppUser> vb.) Contructor'ýna 
 AppUser'ý ve AppRole'u yönetek servisleri yani "UserManager<AppUser>" gibi servisleri enjekte eder.(Dependecy Injection)

"AddErrorDescriber<CustomIdentityValidator>()" ile Identity sistemine bizim özel tanýmladýðýmýz "CustomIdentityValidator" classýný
kullanmasýný söyler
 */
builder.Services.AddIdentity<AppUser, AppRole>()
.AddEntityFrameworkStores<Context>()
	.AddErrorDescriber<CustomIdentityValidator>().AddTokenProvider<DataProtectorTokenProvider<AppUser>>(TokenOptions.DefaultProvider);


// DI sistemine kaydediyoruz. DestinationCQRSController tarafýndan Constructor içerisinde bekkliyor
builder.Services.AddScoped<GetAllDestinationQueryHandler>();
builder.Services.AddScoped<GetDestinationByIdQueryHandler>();
builder.Services.AddScoped<CreateDestinationCommandHandler>();
builder.Services.AddScoped<RemoveDestinationCommandHandler>();
builder.Services.AddScoped<UpdateDestinationCommandHandler>();


// Authorization -> Yetkikendirme, Policy -> Politika ,Authenticated -> Kimliði Doðrulanmýþ, Require -> Gerekli Kýlmak
//  Politika -> türkçede kurallar koymak ve uygulamak için yapýlan faaliyetler demektir.
builder.Services.AddMvc(config =>
{
	var policy = new AuthorizationPolicyBuilder() // AuthorizationPolicyBuilder -> Yetkilendirme Politika Oluþturucusu
	.RequireAuthenticatedUser() // RequireAuthenticatedUser->Kimliði Doðrulanmýþ Kullýcýyý Gerekli Kýl
	.Build(); // Build -> Oluþtur.

	config.Filters.Add(new AuthorizeFilter(policy));

	// Authorize -> Yetki vermek.
	// Bu yapý sayesinden tüm MVC hizmetlerine Yetkilendiriþmiþ kiþi tarafýndan giriþ yapmayý zorunlu kýlýyoruz.(Proje Seviyesinde)
	// Yani gidip tek tek [Authorize] yazmamýza gerek kalmýyor. Projenin geneline [Authorize] uyguluyor.
});



/*
 Bu projede tanýmlanmýþ tüm AutoMapper Frameworkundeki Profil sýnýfýndan miras alan classlarý bul ve CreateMap<> kurallarýný kaydet
Diðer görevi ise IMapper mapper isteyen yerlerden DI sistemi ile  mapper nesnesini enjekte etmesi.
Yani diðer bir deyiþle IMapper DI sistemine eklenir.Yani arayüzlerin nesne örneklerinin Dependency Injection sistemiyle oluþturulur.
 */
builder.Services.AddAutoMapper(typeof(Program));


/*
 Bu projede tanýmlanmýþ tüm IRequest, IRequestHandler, INotification, INotificationHandler gibi MediatR bileþenleini bul,
ve DI Container'a kaydet.Yani arayüzlerin nesne örneklerinin Dependency Injection sistemiyle oluþturulur.
 */
builder.Services.AddMediatR(typeof(Program));




// Bu satýr DI'ya tüm validatorlarý tek kod satýrý ile ekler:
builder.Services.AddValidatorsFromAssemblyContaining<DestinationValidator>(); // Controller tarafýnda new'lemekten kurtulup DI ile enjekte ediyoruz
/*
  "DestinationValidator hangi assembly'deyse, o assembly'deki tüm AbstractValidator<T> sýnýflarýný tara ve IValidator<T> olarak 
   DI sistemine ekle."
Yani yukarýdaki tek satýrlýk kod sayesinde aþaðýdaki gibi tek tek yazmamýza gerek kalmadý tüm Validator sýnýflarýmýzý bulup otomatik DI yapýcak
"builder.Services.AddScoped<IValidator<Category>, CategoryValidator>();"
"builder.Services.AddScoped<IValidator<Reservation>, ReservationValidator>();" 

yani diðer tüm contoller içerisindeki Constructor metodunda farklý tipteki IValidayor<Category> gibi 
doðrulayýcý istendiðinde bu tek satýrlýk kod sayesinde otomatik olarak DI yapýlacak
 */





/*
  "builder.Services.AddDbContext<Context>" ifadesi Context nesnesini DI(Dependecy Injection) Sistemine kaydeder.
   Böylece, Context nesnesi tüm repository sýnýflarýnda tek bir örnek (instance) üzerinden çalýþýr.
   Context sýnýfý tipinde nesneye ihtiyaç duyulan heryerde enjeckte edilir. 
 */
builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))); // appsettings.json dosyasýndaki "DefaultConnection" baðlantý dizesini alýyoruz.



/*
  Dependecy Injection yapýsý sayesinde IAboutRepository isteyen her yere AboutRepository nesnesini otomatik olarak enjekte edicek(vericek).
 
 "AddScoped" ile her HTTP isteði için yeni bir nesne oluþturur ve ayný istekde tekrar kullanýlýr,
  Daha sonra istek bittiðinde DbContext kapatýlýr ve bellek temizlenir.

  Veritabaný baðlantýlarý aðýr iþlemlerdir. Bir isteðe özel baðlantý açýp geri kapatmalýyýz Scope da tam bunu yapar.

 AddScoped -> Her HTTP isteði için yeni bir nesne oluþturup ayný istekde tekrar kullanýr
 AddTransient -> Her çaðrýldýðýnda yeni bir nesne oluþturur. Hafif ve kýsa süreli iþlemlere uygundur. Örneðin : EmailService, SMSService gibi kýsa süreli iþlemler.
 AddSingleton -> Uygulama boyunca ayný nesneyi kullanýr. Statik (deðiþmeyen) servisler için uygundur. Örneðin : CacheService, LoggingService, ConfigurationService gibi deðiþmeyen hizmetler.
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
  Bir hata oluþtuðu zaman ErrorPage Controller altýndaki Error Action'u çalýþtýracak.
  Ayrýca oluþan hatanýn kodu "0" yazan yere yazýlacak. Böylece ErrorPage controller içerisindeki
  Error(int code) ile actionuna hangi durumla ilgili hata oluþtuysa Error(int code) içidenki "code"
  deðerine o hata kodu yazýlýr.

 Yani hangi durumla ile ilgili hata kodu oluþursa ErrorPage Controller'ýn altýndaki Error metoduna o hata kodunu
 Error metoduna parametre olarak gönderilir.
 
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
