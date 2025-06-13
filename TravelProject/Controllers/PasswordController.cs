using DTOLayer.DTOs.PasswordDTOs;
using EntityLayer.Concrete;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TravelProject.Models;

namespace TravelProject.Controllers
{
	[AllowAnonymous]
	public class PasswordController : Controller
	{
		private readonly UserManager<AppUser> _userManager;

		public PasswordController(UserManager<AppUser> userManager)
		{
			_userManager = userManager;
		}

		[HttpGet]
		public IActionResult ForgetPassword()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ForgetPassword(PasswordForgetDTO passwordForgetDTO)
		{
			var user = await _userManager.FindByEmailAsync(passwordForgetDTO.Mail);// formdan gelen maile göre kullanıcı bul
			string passwordResetToken = await _userManager.GeneratePasswordResetTokenAsync(user); // kullanıcının mail adresine benzersiz bir token linki gönderebilmek için
			// kullanıcıya gelen maile tıklayınca calısacak Action tanımlıyoruz
			var passwordTokenLink = Url.Action("ResetPassword", "Password", new
			{
				userId = user.Id,
				token = passwordResetToken
			}, HttpContext.Request.Scheme);

			try
			{

				MimeMessage mimeMessage = new MimeMessage(); // Mailkit framework'ünden gelir ve boş e-posta mesajı oluşturur
															 // Admin -> e-postayı atan tarafın görünen adı
				MailboxAddress mailboxAddressFrom = new MailboxAddress("MHMMD Seyahat Hizmeleri A.Ş.", "seyehathizmetlerimhmmd@gmail.com");
				// User -> e-postayı alan tarafın görünen adı
				MailboxAddress mailboxAddressTo = new MailboxAddress("User", passwordForgetDTO.Mail);
				mimeMessage.From.Add(mailboxAddressFrom); // From -> -den, -dan  -> mailin kimden gönderileceğini belirliyoruz
				mimeMessage.To.Add(mailboxAddressTo); // to -> -e, -ye doğru  -> mailin kime gönderileceğini belirliyoruz
				mimeMessage.Subject = "Şifre Değişiklik Talebi";  // Subject -> Konu , Mailin konu kısmına yazılır

				// mimeMessage.Body alanına direkt string mesaj atayamayız çünkü MimeEntity tipindedir.
				// 
				var bodyBuilder = new BodyBuilder(); // BodyBuilder sınıfı düz metin veya HTML içeriğini oluşturabilmemize yarar
				bodyBuilder.TextBody = passwordTokenLink; // oluşturduğumuz benzersiz token ismine sahip şifre yenileme linkini gönderiyoruz
				mimeMessage.Body = bodyBuilder.ToMessageBody(); // Yukarıda oluşturulan formdan gelen mesaj içeriği , e-postanın gövdesi olarak atanır

				// Bu nesne ile SMTP sunucusuna bağlanılır, kimlik doğrulama yapılır ve mail gönderilir.
				SmtpClient smtpClient = new SmtpClient();
				// Gmail smtp sunucusuna bağlanır, 587 şifreli bağlantılar için kullanılan porttur.
				smtpClient.Connect("smtp.gmail.com", 587, false); // false ile SSL kullanmadan bağlantı açılır
																  // SMTP bağlantısı kurulduktan sonra aşağıda kimlik doğrulama yapılır. 
																  // İlk parametre gönderenin maili, ikinci parametre Google ile oluşturulan uygulama şifresi
				smtpClient.Authenticate("seyehathizmetlerimhmmd@gmail.com", "iwlqrrfwahmlheue");
				smtpClient.Send(mimeMessage); // Maili SMTP sunucu üzerinden gönderiyoruz
				smtpClient.Disconnect(true); // SMTP bağlantısını düzgün ve güvenli şekilde sonlandırır.
				ViewBag.Message = "✅ Şifre Yenileme İsteği Başarılı, Mailinizi Kontrol Ediniz.";
			}
			catch (Exception ex)
			{
				ViewBag.Message = "❌ Hata oluştu: " + ex.Message;

				throw;
			}
			return View();
		}

		[HttpGet]
		public IActionResult ResetPassword(string userId, string token)
		{
			TempData["userId"] = userId;
			TempData["token"] = token;

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> ResetPassword(PasswordResetDTO passwordResetDTO)
		{
			var userId = TempData["userId"];
			var token = TempData["token"];
			if (userId != null && token != null)
			{
				var user = await _userManager.FindByIdAsync(userId.ToString());
				await _userManager.ResetPasswordAsync(user, token.ToString(), passwordResetDTO.Password);
				return RedirectToAction("SignIn", "Login");
			}

			return View();
		}
	}
}
