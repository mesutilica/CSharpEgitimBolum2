using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC.Controllers
{
    public class MVC06SectionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
