using CarOffice.Web.Models;
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
        public IActionResult HttpStatusCodeHandler(int? statusCode)
            => View("_error", new ErrorViewModel
            {
                StatusCode = statusCode ?? 500,
                ErrorMessage = statusCode.HasValue
                    ? "The page you are looking for might have been removed had its name changed or is temporarily unavailable."
                    : HttpContext.Features.Get<IExceptionHandlerPathFeature>().Error.Message
            });
    }
}