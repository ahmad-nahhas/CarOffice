using CarOffice.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CarOffice.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IConfiguration _configuration;

        public ContactController(IConfiguration configuration)
            => _configuration = configuration;

        public IActionResult Index()
            => View();

        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel model)
        {
            try
            {
                if (!ModelState.IsValid) return View(model);

                var host = _configuration["ContactForm:SmtpClient:Host"];
                var port = Convert.ToInt32(_configuration["ContactForm:SmtpClient:Port"]);
                var userName = _configuration["ContactForm:NetworkCredential:UserName"];
                var password = _configuration["ContactForm:NetworkCredential:Password"];
                var receiverEmail = _configuration["ContactForm:ReceiverEmail"];
                var networkCredential = new NetworkCredential(userName, password);

                using var client = new SmtpClient(host, port)
                {
                    Credentials = networkCredential,
                    EnableSsl = true
                };

                await client.SendMailAsync(model.Email,
                                           receiverEmail,
                                           string.IsNullOrWhiteSpace(model.Subject)
                                               ? "Website Contact Form New Message"
                                               : model.Subject,
                                           "You have received a new message from your website contact form." +
                                           "\n\nHere are the details:\n\n" +
                                           $"Name: {model.FullName}\n\n" +
                                           $"Email: {model.Email}\n\n" +
                                           $"Message:\n{model.Message}");

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}