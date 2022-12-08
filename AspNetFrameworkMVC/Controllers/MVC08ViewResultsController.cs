using AspNetFrameworkMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC08ViewResultsController : Controller
    {
        // GET: MVC08ViewResults
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FarkliViewDondur()
        {
            return View("Index"); // FarkliViewDondur action ı çalışınca geriye Index view ını döndür
        }
        public ActionResult Yonlendir()
        {
            //return Redirect("/Home");
            //return Redirect("/Home?kategori=18"); // anasayfaya adres çubuğunda query string yöntemiyle veri yollayabiliriz
            return Redirect("https://www.google.com.tr/"); // uygulama dışında bir yere de yönlendirebiliriz
        }
        public ActionResult ActionaYonlendir()
        {
            //return RedirectToAction("Index");
            //return RedirectToAction("Yonlendir");
            return RedirectToAction("UyeListesi", "MVC05ModelValidation"); // controller ve action u belirtebiliriz
        }
        public RedirectToRouteResult RouteYonlendir()
        {
            return RedirectToRoute("Default", new { controller = "Home", action = "Index", id = 18 });
        }
        public PartialViewResult KategorileriGetirPartial()
        {
            //return PartialView("_KategorilerPartial");
            return PartialView("_PartialLogin");
        }
        public PartialViewResult KategorileriModelleGetirPartial()
        {
            // Partial view dönerken model verisi kullanabiliriz
            List<string> kategoriler = new List<string>()
            {
                "Bilgisayar", "Monitör", "Klavye", "Telefon", "Laptop"
            };
            return PartialView("_KategorilerPartialModelKullanimi", kategoriler);
        }
        public JavaScriptResult JsResult()
        {
            return JavaScript("alert('JavaScriptResult')");
        }
        public JsonResult JsonResult()
        {
            var kullanici = new Kullanici()
            {
                Ad = "Ali",
                Soyad = "Çakmaktaş",
                KullaniciAdi = "acakmak",
                Email = "ali@cakmaktas.com"
            };
            return Json(kullanici, JsonRequestBehavior.AllowGet); // JsonRequestBehavior.AllowGet özelliği bu metoda gelen get isteklerine izin ver demek
        }
        public ContentResult XmlContentResult()
        {
            var xml = @"
                <urunler>
                    <urun>
                        <Id>1</Id>
                        <UrunAdi>Klavye</UrunAdi>
                        <Fiyati>199</Fiyati>
                        <Stok>3</Stok>
                        <Kategori>Bilgisayar</Kategori>
                    </urun>
                    <urun>
                        <Id>2</Id>
                        <UrunAdi>Mouse</UrunAdi>
                        <Fiyati>99</Fiyati>
                        <Stok>5</Stok>
                        <Kategori>Bilgisayar</Kategori>
                    </urun>
                </urunler>
            ";

            return Content(xml, "application/xml"); // geriye xml formatında içerik dön
        }
    }
}