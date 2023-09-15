using Microsoft.AspNetCore.Mvc;

namespace AllupProjectT.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
