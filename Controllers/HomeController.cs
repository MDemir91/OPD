using Microsoft.AspNetCore.Mvc;
using OPD.Models;
using System.Diagnostics;

namespace OPD.Controllers
{
    public class HomeController : Controller
    {
        private readonly string correctPassword = "Adamar.1905";

        [HttpGet]
        public IActionResult Index(string error = null)
        {
            ViewBag.ErrorMessage = error;
            return View();
        }

        [HttpPost]
        public IActionResult Login(string password)
        {
            if (password == correctPassword)
            {
                return RedirectToAction("Panel");
            }
            else
            {
                return RedirectToAction("Index", new { error = "Hatalý þifre, lütfen tekrar deneyin." });
            }
        }

        public IActionResult Panel()
        {
            return View();
        }

        // Mesaj sayfasý, tüm butonlar buraya yönlendirilecek
        public IActionResult Mesaj()
        {
            return View();
        }

        // Çýkýþ için örnek redirect, istersen login sayfasýna da gönderebilirsin
        public IActionResult Exit()
        {
            // Örnek: Giriþ sayfasýna yönlendir
            return RedirectToAction("Index");
        }
    }

}
