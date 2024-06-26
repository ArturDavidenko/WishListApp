using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WishListApp.Models;
using WishListApp.Repository;

namespace WishListApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly WishRepository _repository;

        public HomeController(WishRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
       
        public async Task<IActionResult> HomePage()
        {
            var wishItems =  await _repository.GetWishItems();
            return View(wishItems);
        }


        public async Task<IActionResult> GetWishItemView(int id)
        {
            var wishItem =  await _repository.GetWishItem(id);
            return View("WishItemViewPage", wishItem);
        }

        public async Task<IActionResult> DeleteWishItem(int id)
        {
            await _repository.DeleteWishItem(id);
            return RedirectToAction("HomePage");
        }

    }
}
