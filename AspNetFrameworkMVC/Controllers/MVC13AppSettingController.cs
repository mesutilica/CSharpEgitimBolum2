using System.Web.Configuration; // web configden veri çekme kütüphanesi
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC13AppSettingController : Controller
    {
        // GET: MVC13AppSetting : web.config dosyasından veri okumak için kullanırız
        public ActionResult Index()
        {
            ViewBag.Usr = WebConfigurationManager.AppSettings["EmailUserName"];
            ViewBag.Pwd = WebConfigurationManager.AppSettings["EmailPassWord"];
            return View();
        }
    }
}