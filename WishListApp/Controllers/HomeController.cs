using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WishListApp.Models;

namespace WishListApp.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
