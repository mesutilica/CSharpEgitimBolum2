using AspNetFrameworkMVC.Filters;
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC14FiltersUsingController : Controller
    {
        // GET: MVC14FiltersUsing
        [UserControl] // Index action ına istek gelince UserControl class ı içerisindeki mekanizma oraya yazdığımız session ve cookie kurallarına bakarak kullanıcı giriş yapmışsa sayfayı açacak, yapmamışsa istediğimiz bir sayfaya yönlendirilecek
        public ActionResult Index()
        {
            TempData["SessionBilgi"] = Session["deger"];

            if (HttpContext.Request.Cookies["username"] != null)
                TempData["CookieBilgi"] = HttpContext.Request.Cookies["username"].Value;

            return View();
        }
    }
}