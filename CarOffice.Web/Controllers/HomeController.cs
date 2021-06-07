using CarOffice.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace CarOffice.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
            => View();

        public IActionResult Privacy()
            => View();

        [Route("Home/Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
            => View("_error", new ErrorViewModel
            {
                StatusCode = statusCode,
                ErrorMessage = "The page you are looking for might have been removed had its name changed or is temporarily unavailable."
            });

        [AllowAnonymous]
        [Route("Home/Error")]
        public IActionResult Error()
            => View("_error", new ErrorViewModel
            {
                StatusCode = 500,
                ErrorMessage = HttpContext.Features.Get<IExceptionHandlerPathFeature>().Error.Message
            });
    }
}