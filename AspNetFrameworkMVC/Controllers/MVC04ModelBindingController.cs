using AspNetFrameworkMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC04ModelBindingController : Controller
    {
        // GET: MVC04ModelBinding
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kullanici()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "info@yoneciti.com",
                KullaniciAdi = "murat",
                Sifre = "123456"
            };

            return View(kullanici); // yukardaki kullanici nesnesinin view da model olarak kullanılabilmesi için bu şekilde view a göndermemiz gerekir.
        }
        [HttpPost]
        public ActionResult Kullanici(Kullanici kullanici) // parantez içerisinde Kullanici sınıfından kullanici isminde bir nesne alacağımızı belirttik
        {
            return View(kullanici); // yukardaki kullanici nesnesinin view da model olarak kullanılabilmesi için bu şekilde view a göndermemiz gerekir.
        }
        public ActionResult Adres()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Adres(Adres adres)
        {
            return View(adres);
        }
        public ActionResult KullaniciSayfasi()
        {
            Kullanici kullanici = new Kullanici()
            {
                Ad = "Murat",
                Soyad = "Yılmaz",
                Email = "info@yoneciti.com",
                KullaniciAdi = "murat",
                Sifre = "123456"
            };
            UyeSayfasiViewModel model = new UyeSayfasiViewModel()
            {
                Kullanici = kullanici,
                Adres = new Adres { Sehir = "İstanbul", Ilce = "Ataşehir", AcikAdres = "Açık adres" }
            };
            return View(model);
        }
    }
}