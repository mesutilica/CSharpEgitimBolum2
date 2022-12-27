using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC.Controllers
{
    public class MVC13AppSettingController : Controller
    {
        private readonly IConfiguration _configuration;

        public MVC13AppSettingController(IConfiguration configuration) // D.I
        {
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            TempData["Email"] = _configuration["Email"]; // TempData ile appsettings deki Email bilgisini okuyup view a gönderdik
            TempData["MailSunucu"] = _configuration["MailSunucu"];
            TempData["UserName"] = _configuration["MailKullanici:UserName"];
            TempData["Password"] = _configuration.GetSection("MailKullanici:Password").Value;
            return View();
        }
    }
}
