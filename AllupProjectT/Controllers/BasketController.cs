using AllupProjectT.DataAccessLayer;
using AllupProjectT.Models;
using AllupProjectT.ViewModels.BasketVMs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AllupProjectT.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id == null) return BadRequest("Id Is Not Be Null");

            Product product = await _context.Products
                .Include(p => p.ProductImages.Where(pi => pi.IsDeleted == false))
                .FirstOrDefaultAsync(p => p.IsDeleted == false && p.Id == id);
            if (product == null) return NotFound("Id Is InCorrect");

            string? basket = Request.Cookies["basket"];
            List<BasketVM> basketVMs = null;
            if (!string.IsNullOrEmpty(basket))
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(basket);

                if (basketVMs.Exists(b => b.Id == id))
                {
                    basketVMs.Find(b => b.Id == id).Count += 1;
                }
                else
                {

                    
                    basketVMs.Add(new BasketVM
                    {
                        Id = product.Id,
                        Title = product.Title,
                        ExTax = product.ExTag,
                        Image = product.MainImage,
                        Price = product.Price,
                        Count = 1,
                    });
                }

            }
            else
            {
                basketVMs = new List<BasketVM> {  new BasketVM
                {
                    Id = product.Id,
                    Title = product.Title,
                    ExTax = product.ExTag,
                    Image = product.MainImage,
                    Price = product.Price,
                    Count=1,
                } };


            }
            basket = JsonConvert.SerializeObject(basketVMs);

            Response.Cookies.Append("basket", basket);


            return PartialView("_BasketPartial", basketVMs);
        }

    }
}
