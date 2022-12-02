using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC03DataTransferController : Controller
    {
        // GET: MVC03DataTransfer
        public ActionResult Index(string txtAra)
        {
            // MVC de temel olarak 3 türde view a veri yollama yapısı var
            // Örneğin veritabanından ürün bilgisini çekip ekrana  yollamak için

            // 1- ViewBag : Tek Kullanımlık Ömrü Var
            ViewBag.UrunKategorisi = "Bilgisayar";
            // 2-Viewdata : Tek Kullanımlık Ömrü Var
            ViewData["UrunAdi"] = "Acer Monitör";
            // 3-TempData : 2 Kullanımlık Ömrü Var
            TempData["UrunFiyati"] = 3518;

            ViewBag.GetVerisi = txtAra;

            return View();
        }
        [HttpPost] // aşağıdaki metodun sadece post yönteminde çalışmasını sağlar
        public ActionResult Index(string text1, string ddlListe, bool cbOnay, FormCollection formCollection)
        {
            // 1. Yöntem parametrelerden gelen veriler;

            ViewBag.Mesaj = "Textboxdan gelen veri : " + text1;
            ViewBag.MesajListe = "liste den seçilen değer : " + ddlListe;
            TempData["Tdata"] = "Checkbox dan seçilen değer : " + cbOnay;

            // 2. Yöntem Request Form ile verileri yakalama

            ViewBag.Mesaj2 = "Textboxdan gelen veri : " + Request.Form["text1"];
            ViewBag.MesajListe2 = "liste den seçilen değer : " + Request.Form["ddlListe"];
            TempData["Tdata2"] = "Checkbox dan seçilen değer : " + Request.Form.GetValues("cbOnay")[0]; // checkbox verisi bu şekilde yakalanıyor

            // 3. Yöntem FormCollection ile verileri yakalama

            ViewBag.Mesaj3 = "Textboxdan gelen veri : " + formCollection["text1"];
            ViewBag.MesajListe3 = "liste den seçilen değer : " + formCollection["ddlListe"];
            TempData["Tdata3"] = "Checkbox dan seçilen değer : " + formCollection.GetValues("cbOnay")[0];

            return View();
        }
    }
}