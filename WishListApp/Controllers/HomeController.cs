using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using WishListApp.Models;

namespace WishListApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
       
        public async Task<IActionResult> HomePage()
        {
            List<WishItem> wishItems = new List<WishItem>();

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync("https://localhost:7043/api/WishItem");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    wishItems = JsonSerializer.Deserialize<List<WishItem>>(jsonResponse);
                }
                
            }

            return View(wishItems);
        }


        public async Task<IActionResult> GetWishItemView(int id)
        {
            WishItem wishItem = null;

            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync($"https://localhost:7043/api/WishItem/{id}");

                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    wishItem = JsonSerializer.Deserialize<WishItem>(jsonResponse);
                }

            }
            return View("WishItemViewPage", wishItem);
        }

        public async Task<IActionResult> DeleteWishItem(int id)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                var response = await httpClient.DeleteAsync($"https://localhost:7043/api/WishItem/{id}");
            }

            return RedirectToAction("HomePage");
        }

    }
}
