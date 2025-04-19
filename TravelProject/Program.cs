using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using TravelProject.Models;

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
	.AddErrorDescriber<CustomIdentityValidator>();
	
	

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
	name: "default",
	pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
