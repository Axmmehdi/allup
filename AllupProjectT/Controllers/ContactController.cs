using Microsoft.AspNetCore.Mvc;

namespace AllupProjectT.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
