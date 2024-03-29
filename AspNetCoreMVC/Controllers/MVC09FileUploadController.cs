﻿using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreMVC.Controllers
{
    public class MVC09FileUploadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(IFormFile? Image) // .net core da resim yükleme için IFormFile interface ini kullanıyoruz
        {
            if (Image is not null)
            {
                string directory = Directory.GetCurrentDirectory() + "/wwwroot/Img/" + Image.FileName;
                using var stream = new FileStream(directory, FileMode.Create); // Buradaki using ifadesi stream isimli değişkenin işinin bittikten sonra bellekten atılmasını sağlar
                Image.CopyTo(stream); // resmi asenkron olarak yükledik
                TempData["Resim"] = Image.FileName;
            }
            return View();
        }
    }
}
