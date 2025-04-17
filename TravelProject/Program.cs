using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

var builder = WebApplication.CreateBuilder(args);

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
