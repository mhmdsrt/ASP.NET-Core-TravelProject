using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using TravelProject.Models;

namespace TravelProject.Areas.Admin.Controllers
{
	[AllowAnonymous]
	[Area("Admin")]
	[Route("Admin/[Controller]/[Action]/{id?}")]
	public class MailController : Controller
	{
		[HttpGet]
		public IActionResult SendingMail() // Sending Mail -> Mail Gönderme
		{
			return View();
		}

		[HttpPost]
		public IActionResult SendingMail(MailRequest mailRequest) // Sending Mail -> Mail Gönderme
		{
			try
			{
				MimeMessage mimeMessage = new MimeMessage(); // Mailkit framework'ünden gelir ve boş e-posta mesajı oluşturur
				// Admin -> e-postayı atan tarafın görünen adı
				MailboxAddress mailboxAddressFrom = new MailboxAddress("MHMMD Seyahat Hizmeleri A.Ş.", "seyehathizmetlerimhmmd@gmail.com");
				// User -> e-postayı alan tarafın görünen adı
				MailboxAddress mailboxAddressTo = new MailboxAddress("User", mailRequest.ReceiverMail);
				mimeMessage.From.Add(mailboxAddressFrom); // From -> -den, -dan  -> mailin kimden gönderileceğini belirliyoruz
				mimeMessage.To.Add(mailboxAddressTo); // to -> -e, -ye doğru  -> mailin kime gönderileceğini belirliyoruz
				mimeMessage.Subject = mailRequest.Subject;  // Subject -> Konu , Mailin konu kısmına yazılır

				// mimeMessage.Body alanına direkt string mesaj atayamayız çünkü MimeEntity tipindedir.
				// 
				var bodyBuilder = new BodyBuilder(); // BodyBuilder sınıfı düz metin veya HTML içeriğini oluşturabilmemize yarar
				bodyBuilder.TextBody = mailRequest.Body; // Formdan gelen e-postanın mesaj içeriği Body entitysinin text kısmına yazılır
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

				ViewBag.Message = "✅ Mail başarıyla gönderildi.";

			}
			catch (Exception ex)
			{

				ViewBag.Message = "❌ Hata oluştu: " + ex.Message;
			}

			return View();
		}
	}
}
