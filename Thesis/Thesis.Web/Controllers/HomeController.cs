using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Thesis.Web.DAL;
using Thesis.Web.Models;

namespace Thesis.Web.Controllers
{
    public class HomeController : Controller
    {
        DbHelper db = new DbHelper();
        [HttpGet]
        public ActionResult Login()
        {
            Users usuario = db.GetUsuario(1);
            return View(usuario);
        }
        [HttpPost]
        public ActionResult Login(Users model)
        {
            Users usuario = db.GetUsuario(1);
            return View(usuario);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}