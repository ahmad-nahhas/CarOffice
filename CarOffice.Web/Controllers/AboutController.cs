using Microsoft.AspNetCore.Mvc;

namespace CarOffice.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
            => View();
    }
}