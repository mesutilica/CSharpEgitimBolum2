using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC.Controllers
{
    public class MVC07PartialController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
