using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebThesis.DAL;
using WebThesis.Models;

namespace WebThesis.Controllers
{
    public class HomeController : Controller
    {
        DALHelper helper = new DALHelper();
        Random r = new Random((int)DateTime.Now.Ticks);
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //User user = new User()
            //{
            //    UserName = "cc.segura",
            //    Password = "12345",
            //    Mail = "cc.segura@uniandes.edu.co"
            //};
            //helper.InsertUser(user);
        }

        #region Pagina de inicio
        [HttpGet]
        public IActionResult Index()
        {
            var isLogged = HttpContext.Session.GetInt32("isLoggedIn");
            if (isLogged == null)
                return Redirect("/Home/Login");
            if (isLogged == 0)
            {
                return Redirect("/Home/Login");
            }
            else
            {

                List<Device> model = helper.GetDevices();


                return View(model);
            }
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            ViewBag.Title = "Inicio de sesion";
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                User temp = new User()
                {
                    UserName = model.UserName,
                    Password = model.Password
                };
                if (helper.ValidateUser(temp))
                {
                    HttpContext.Session.SetInt32("isLoggedIn", 1);
                    return Redirect("/Home/Index");
                }
            }

            return View();
        }
        #endregion
        [HttpPost]
        public IActionResult DeviceController(Device model)
        {
            switch (model.Controller.ToLower())
            {
                case "potentiostat":
                    return Redirect("/Potentiostat/Index");
                default:
                    return Redirect("/Home/Index");
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
