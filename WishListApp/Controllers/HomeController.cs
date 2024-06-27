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

        public IActionResult WishItemAddPage()
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

        public async Task<IActionResult> EditWishItemPage(int id)
        {
            var wishItem = await _repository.GetWishItem(id);
            return View("EditWishItemPage", wishItem);
        }

        public async Task<IActionResult> EditWishItem(WishItem wishitem)
        {
            await _repository.UpdateWishItem(wishitem);
            return RedirectToAction("HomePage");
        }

        public async Task<IActionResult> DeleteWishItem(int id)
        {
            await _repository.DeleteWishItem(id);
            return RedirectToAction("HomePage");
        }

        public async Task<IActionResult> CreateWishItem(WishItem wishItem)
        {
            await _repository.CreateWishItem(wishItem);
            return RedirectToAction("HomePage");
        }

    }
}
