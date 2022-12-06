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
            return RedirectToRoute("Default", new { controller = "Home", action = "Index", id=18 });
        }
    }
}