using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC11SessionController : Controller
    {
        // GET: MVC11Session
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SessionOlustur(string kullaniciAdi, string sifre)
        {
            if (kullaniciAdi == "admin" && sifre == "123")
            {
                Session["deger"] = "Admin";
            }
            //return View("SessionOku");
            return RedirectToAction("SessionOku");
        }
        public ActionResult SessionOku()
        {
            TempData["SessionBilgi"] = Session["deger"];
            return View();
        }
        public ActionResult SessionSil()
        {
            if (Session["deger"] != null)
                HttpContext.Session.Remove("deger");
            return RedirectToAction("SessionOku");
        }
    }
}