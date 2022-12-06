using AspNetFrameworkMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC05ModelValidationController : Controller
    {
        static List<Uye> uyeListesi = new List<Uye>()
         {
             new Uye() { Id = 1, Ad = "Alp", Soyad = "Arslan", Email ="alp@siteadi.com"  },
             new Uye() { Id = 2, Ad = "Murat", Soyad = "Yılmaz", Email ="murat@kartipi.com"  },
             new Uye() { Id = 3, Ad = "Mesut", Soyad = "Ilıca", Email = "mesut@gmail.net" }
         };
        // GET: MVC05ModelValidation
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult UyeListesi()
        {
            return View(uyeListesi); // Ekrana modeli view içerisinde gönderebiliyoruz
        }
        public ActionResult YeniUye()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniUye(Uye uye)
        {
            if (ModelState.IsValid) // Eğer modeldeki validasyon kurallarına uyulmuşsa, tersi için !ModelState.IsValid
            {
                uye.Id = uyeListesi.Count + 1;
                uyeListesi.Add(uye);
                // Parametreyle gelen uye nesnesini burada veritabanına kaydedebiliriz
                return RedirectToAction("UyeListesi");
            }
            return View(uye);
        }
        public ActionResult UyeDuzenle(int id)
        {
            var uyeBilgileri = uyeListesi.FirstOrDefault(u => u.Id == id);
            return View(uyeBilgileri);
        }
        [HttpPost]
        public ActionResult UyeDuzenle(int id, Uye uye)
        {
            if (ModelState.IsValid)
            {
                // burada güncelleme yapılır
                return RedirectToAction("UyeListesi");
            }
            return View(uye);
        }
        public ActionResult UyeSil(int id)
        {
            var uyeBilgileri = uyeListesi.FirstOrDefault(u => u.Id == id);
            return View(uyeBilgileri);
        }
        [HttpPost]
        public ActionResult UyeSil(int id, Uye uye)
        {
            if (ModelState.IsValid)
            {
                // burada silme yapılır
                return RedirectToAction("UyeListesi");
            }
            return View(uye);
        }
    }
}