using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetFrameworkMVC.Controllers
{
    public class MVC01RazorSyntaxController : Controller
    {
        // GET: MVC01RazorSyntax
        public ActionResult Index()
        {
            return View();
        }
    }
}