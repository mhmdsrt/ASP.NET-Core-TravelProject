using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TravelProject.Areas.Member.Models;

namespace TravelProject.Areas.Member.Controllers
{
	[Area("Member")]
	[Route("Member/[Controller]/[Action]")]

	/*
	 [Route("Member/[Controller]/[Action]")] -> Bu ifade ile ProfileController'a şunu yaptırıyoruz:
	  Bu Controller içerisinde Sadece "Member/Profile/Action" URL istekleri geldiğinde çalış diyoruz. 
	  Çünkü ProfileController, "Member" ismindeki bir Area'nın içerisinde olduğu için eğer biz Route[] ile yapılandırma yapmazsak
	  default olarak Profile/Index/Id? calısacak ama başına Area'nın ismi olan Member gelmeyecek. Dolayısıyla	 böyle bir yapıya ihtiyaç duyduk.
	   
	  Ayrıca [Controller] ifadesi ile içinde bulunduğu Controller'ın ismini otomatik alır.

	Yani [Route] yapısı hangi URL isteklerinde hangi Controller ve Controller altındaki Action'ların calısacağını belirler.
    Route -> Rota
	 */
	public class ProfileController : Controller
	{
		private readonly UserManager<AppUser> _userManager; // Kullanıcı bilgilerini düzenleyebilmek için kullanacağımız service
		public ProfileController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			UserProfileEditViewModel userProfileEditViewModel = new UserProfileEditViewModel();

			var values = await _userManager.FindByNameAsync(User.Identity.Name);
			// FindByNameAsync(User.Identity.Name) -> AspNetUsers tablosundaki UserName sütununa karşılık gelir
			userProfileEditViewModel.Name = values.Name;
			userProfileEditViewModel.SurName = values.SurName;
			userProfileEditViewModel.PhoneNumber = values.PhoneNumber;
			userProfileEditViewModel.Mail = values.Email;

			return View(userProfileEditViewModel);
		}

		[HttpPost]

		public async Task<IActionResult> Index(UserProfileEditViewModel userProfileEditViewModel)
		{
			var user = await _userManager.FindByNameAsync(User.Identity.Name); // AspNetUsers tablosundaki UserName sütununa karşılık gelir

			if (userProfileEditViewModel.ImageFile != null)
			{
				var extension = Path.GetExtension(userProfileEditViewModel.ImageFile.FileName);
				var imageName = Guid.NewGuid() + extension;
				var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/UserImages/" + imageName); // Dosyanın kaydedileceği tam yolu oluşturur
				var stream = new FileStream(location, FileMode.Create); // Yeni bir akış oluşturur. location'daki konuma Create işlemi için yeni bir akış.
				await userProfileEditViewModel.ImageFile.CopyToAsync(stream); // location konumuna FileMode.Create(Dosya oluşturma) işlemi açılan akış üzerinden dosyayı kopyalar.
				user.ImageUrl = imageName;
			}

			user.Name = userProfileEditViewModel.Name;
			user.SurName = userProfileEditViewModel.SurName;
			user.PhoneNumber = userProfileEditViewModel.PhoneNumber;
			user.Email = userProfileEditViewModel.Mail;
			user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userProfileEditViewModel.Password);
			var result = await _userManager.UpdateAsync(user);
			if (result.Succeeded)
			{
				return RedirectToAction("SignIn", "Login");
			}

			return View();

		}
		/*
	  ".FileName" ile dosyanın adını alıyoruz. extension -> uzantı, path -> yol
		Path.GetExtension() -> Dosyanın uzantısını alır. Örneğin: ".jpg "veya ".png"

		Guid.NewGuid() -> Benzersin bir kimlik(UUID) oluşturur. Örneğin:3f1a8f5b-678c-4e0d-934a-7c72c4b8e0b6
		Guid.NewGuid() + extension  ifadesi ile oluşturduğu benzersiz kimlik ile uzantıyı birleştirir -> 3f1a8f5b-678c-4e0d-934a-7c72c4b8e0b6.jpg

		Directory.GetCurrentDirectory() -> Projenin çalıştığı dizini döndürür, Directory -> Dizin , CurrentDirectory -> Geçerli Dizin
		 "wwwroot/UserImages/" + newImageName -> Yeni resim dosyasının kaydedileceği dizini belirler
		Path.Combine() -> Güvenli bir dosya yolu oluşturur, aşağıdaki aldığı parametreler sonucu örneğin şöyle bir şey oluşturuacak : "C:\Projects\MyApp\wwwroot\WriterAddedImages\3f1a8f5b-678c-4e0d-934a-7c72c4b8e0b6.jpg" böylelikle dosyanın kaydedileceği yeri oluşturuyoruz

		new FileStream(location, FileMode.Create):
		FileStream -> Belirtilen yolda dosya akışı(stream) açar.  Dosya işlemleri için kullanılır, dosya okuma-yazma için.
		Buradaki location -> Dosyanın kaydedileceği tam yol
		Buradaki FileMode.Create -> Belirtilen konumda dosya varsa onu silip yenisini oluşturur , dosya yoksa yenisini oluşturur.



		 */
	}
}
