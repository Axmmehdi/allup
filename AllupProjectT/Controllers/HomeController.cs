using AllupProjectT.DataAccessLayer;
using AllupProjectT.Models;
using AllupProjectT.Services;
using AllupProjectT.ViewModels.HomeVM;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Configuration;

namespace AllupProjectT.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            

            _context = context;
        }

        

        public  async Task<IActionResult> Index()
        {
           
            
            HomeVM homeVM = new HomeVM
            {
                Sliders = await _context.Sliders.Where(s => s.IsDeleted == false).ToListAsync(), 
                Categories = await _context.Catagoires.Where(c => c.IsDeleted == false && c.IsMain == true).ToListAsync(),
                NewArrival = await _context.Products.Where(p=>p.IsDeleted == false && p.IsNewArrival).ToListAsync(),
                BestSeller = await _context.Products.Where(p=>p.IsDeleted == false && p.IsBestSeller).ToListAsync(),
                Featured = await _context.Products.Where(p=>p.IsDeleted == false && p.IsFeatured).ToListAsync()
            };
            return View(homeVM);
        }


        public IActionResult SetCookie()
        {
            Response.Cookies.Append("firstcookie", "Hola Amigo miamoto");

            return Ok();

        }


        public IActionResult GetCookie()
        {
           string cookie = Request.Cookies["Basket"];

            return Ok(cookie);
        }


        //public IActionResult SetSession()
        //{
        //    HttpContext.Session.SetString("firstsession", "P235 hola amigo ");
        //    return Ok();
        //}

        //public IActionResult GetSession()
        //{
        //    string session = HttpContext.Session.GetString("firstsession");

        //    return Ok(session);
        //}
    }
}
