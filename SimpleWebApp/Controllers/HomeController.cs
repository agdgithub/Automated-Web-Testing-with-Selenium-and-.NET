using Microsoft.AspNetCore.Mvc;
using SimpleWebApp.Models;

namespace SimpleWebApp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitForm(UserModel user)
        {
            return View("Index", user);
        }
    }
}
