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
                else
                {
                    // Обработка ошибок
                    ViewBag.Error = "Не удалось получить данные от API.";
                }
            }

            return View(wishItems);
        }
    }
}
