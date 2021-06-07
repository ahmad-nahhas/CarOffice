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
        {
            _configuration = configuration;
        }

        public IActionResult Index()
            => View();

        [HttpPost]
        public async Task<IActionResult> Index(ContactViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using var client = new SmtpClient(_configuration["ContactForm:SmtpClient:Host"],
                        Convert.ToInt32(_configuration["ContactForm:SmtpClient:Port"]));

                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(_configuration["ContactForm:NetworkCredential:UserName"],
                        _configuration["ContactForm:NetworkCredential:Password"]);

                    await client.SendMailAsync(model.Email, _configuration["ContactForm:ReceiverEmail"],
                        string.IsNullOrWhiteSpace(model.Subject) ? "Website Contact Form New Message" : model.Subject,
                        "You have received a new message from your website contact form.\n\nHere are the details:\n\nName: " +
                        $"{model.FullName}\n\nEmail: {model.Email}\n\nMessage:\n{model.Message}");
                }

                return RedirectToAction(nameof(Index), "Home");
            }
            catch
            {
                return RedirectToAction(nameof(Index), "Home");
            }
        }
    }
}