using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProniaAB104.DAL;
using ProniaAB104.Models;
using ProniaAB104.ViewModels;
using System.Security.Claims;

namespace ProniaAB104.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;

        public BasketController(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<BasketItemVM> basketVM = new List<BasketItemVM>();

            if (Request.Cookies["Basket"] is not null)
            {
                List<BasketCookieItemVM> basket = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(Request.Cookies["Basket"]);

                foreach (var basketCookieItem in basket)
                {
                    Product product = await _context.Products.Include(p => p.ProductImages.Where(pi => pi.IsPrimary == true)).FirstOrDefaultAsync(p => p.Id == basketCookieItem.Id);
                    if (product is not null)
                    {
                        BasketItemVM basketItemVM = new BasketItemVM
                        {
                            Id = product.Id,
                            Name = product.Name,
                            Image = product.ProductImages.FirstOrDefault().Url,
                            Price = product.Price,
                            Count = basketCookieItem.Count,
                            SubTotal = product.Price * basketCookieItem.Count
                        };
                        basketVM.Add(basketItemVM);
                    }
                }
            }


            return View(basketVM);
        }

        public async Task<IActionResult> AddBasket(int id)
        {
            if (id <= 0) return BadRequest();

            Product product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return NotFound();
            //if (User.Identity.IsAuthenticated)
            //{
            //    AppUser user = await _userManager.Users.Include(u => u.BasketItems).FirstOrDefaultAsync(u => u.Id == User.FindFirst(ClaimTypes.NameIdentifier.Value);
            //}
            List<BasketCookieItemVM> basket;

            if (Request.Cookies["Basket"] is not null)
            {
                basket = JsonConvert.DeserializeObject<List<BasketCookieItemVM>>(Request.Cookies["Basket"]);

                BasketCookieItemVM item = basket.FirstOrDefault(b => b.Id == id);
                if (item is null)
                {
                    BasketCookieItemVM basketCookieItemVM = new BasketCookieItemVM
                    {
                        Id = id,
                        Count = 1
                    };
                    basket.Add(basketCookieItemVM);
                }
                else
                {
                    item.Count++;
                }
            }
            else
            {
                basket = new List<BasketCookieItemVM>();
                BasketCookieItemVM basketCookieItemVM = new BasketCookieItemVM
                {
                    Id = id,
                    Count = 1
                };
                basket.Add(basketCookieItemVM);
            }






            string json = JsonConvert.SerializeObject(basket);

            Response.Cookies.Append("Basket", json);

            return RedirectToAction(nameof(Index), "Home");

        }
        public async Task<IActionResult> GetBasket()
        {

            return Content(Request.Cookies["Basket"]);
        }

    }
}
