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
                return RedirectToAction("Index", new { error = "Hatal� �ifre, l�tfen tekrar deneyin." });
            }
        }

        public IActionResult Panel()
        {
            return View();
        }

        // Mesaj sayfas�, t�m butonlar buraya y�nlendirilecek
        public IActionResult Mesaj()
        {
            return View();
        }

        // ��k�� i�in �rnek redirect, istersen login sayfas�na da g�nderebilirsin
        public IActionResult Exit()
        {
            // �rnek: Giri� sayfas�na y�nlendir
            return RedirectToAction("Index");
        }
    }

}
