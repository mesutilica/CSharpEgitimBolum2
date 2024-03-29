﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC.Controllers
{
    public class MVC11SessionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SessionOlustur(string kullaniciAdi, int sifre)
        {
            if (kullaniciAdi == "admin" && sifre == 123)
            {
                HttpContext.Session.SetString("Kullanici", kullaniciAdi); // session da string olarak key value şeklinde değer saklayabiliriz
                HttpContext.Session.SetInt32("Sifre", sifre);
                HttpContext.Session.SetString("UserGuid", Guid.NewGuid().ToString());
                return RedirectToAction("SessionOku");
            }
            return View();
        }
        public IActionResult SessionOku()
        {
            TempData["SessionBilgi"] = HttpContext.Session.GetString("Kullanici"); // sessiondaki veriye bu şekilde keye verdiğimiz isimle ulaşıyoruz
            TempData["Sifre"] = HttpContext.Session.GetInt32("Sifre");
            TempData["UserGuid"] = HttpContext.Session.GetString("UserGuid");
            return View();
        }
        [HttpPost]
        public IActionResult SessionSil()
        {
            HttpContext.Session.Remove("Kullanici"); // Kullanici isimli sessionu süresini beklemeden sil
            return RedirectToAction("SessionOku");
        }
    }
}
