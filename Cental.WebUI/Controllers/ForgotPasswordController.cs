using System;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MimeKit;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using Cental.EntityLayer.Entities;
using Cental.DtoLayer.UserDtos;
using Microsoft.AspNetCore.Authorization;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class ForgotPasswordController(UserManager<AppUser> _userManager) : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ForgotPasswordUserDto model)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                // Şifre sıfırlama token'ı oluştur
                string resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

                // Şifre sıfırlama bağlantısını oluştur
                string resetLink = Url.Action("UpdatePassword", "User", new { userId = user.Id, token = HttpUtility.UrlEncode(resetToken) }, Request.Scheme);

                // E-posta nesnesini hazırla
                Email email = new Email
                {
                    To = user.Email,
                    Subject = "Şifre Güncelleme Talebi",
                    Body = $"<p>Şifrenizi sıfırlamak için aşağıdaki bağlantıya tıklayın:</p><a href='{resetLink}'>Şifreyi Sıfırla</a>"
                };

                // Mail gönder
                await SendEmail(email);

                Console.WriteLine("E-Posta başarıyla gönderildi!");
            }
            else
            {
                Console.WriteLine("hata");
            }
            return View();
        }

        private async Task SendEmail(Email email)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("Şifre Sıfırlama", "elifarslannx001@gmail.com")); // Gönderen mail
            message.To.Add(new MailboxAddress("", email.To)); // Alıcı mail
            message.Subject = email.Subject;

            var bodyBuilder = new BodyBuilder
            {
                HtmlBody = email.Body
            };
            message.Body = bodyBuilder.ToMessageBody();

            using (var smtp = new SmtpClient())
            {
                try
                {
                    await smtp.ConnectAsync("smtp.gmail.com", 587, MailKit.Security.SecureSocketOptions.StartTls); // Outlook SMTP Sunucusu
                    await smtp.AuthenticateAsync("elifarslannx001@gmail.com", "Giris123*"); // Kullanıcı adı ve şifre (Outlook hesabınla ilgili)
                    await smtp.SendAsync(message);
                    await smtp.DisconnectAsync(true);
                    Console.WriteLine("E-Posta başarıyla gönderildi!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Hata oluştu: {ex.Message}");
                }
            }
        }
    }
}
