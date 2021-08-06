using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ThesisCore.Models;

namespace ThesisCore.Controllers
{
    public class HomeController : Controller
    {
        DAL helper = new DAL();
        Random r = new Random((int)DateTime.Now.Ticks);
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

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
                HomeModel model = new HomeModel();
                model.Devices = helper.GetDevices();


                return View(model);
            }
        }
        #endregion

        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            LoginModel model = new LoginModel();
            ViewBag.Title = "Inicio de sesion";
            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginModel model)
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
        public IActionResult DeviceController(int id)
        {
            switch (id)
            {
                case 1:
                    return Redirect("/Home/Potenciostato");
                default:
                    return Redirect("/Home/Index");
            }
        }
        [HttpGet]
        public IActionResult Potenciostato()
        {
            PotenciostatoModel modelo = new PotenciostatoModel();
            modelo.data = new List<DataPotenciostato>()
            {
                new DataPotenciostato()
                {
                    IdUser=1,
                    DateRun= DateTime.Now,
                    Description="Primera prueba"
                }
            };
            return View(modelo);
        }

        [HttpGet]
        public JsonResult PotData()
        {
            List<DatosChart> datos = new List<DatosChart>()
            {
                new DatosChart(){ Voltaje=r.NextDouble(), Corriente=r.NextDouble() },
                new DatosChart(){ Voltaje=r.NextDouble(), Corriente=r.NextDouble() },
                new DatosChart(){ Voltaje=r.NextDouble(), Corriente=r.NextDouble() },
                new DatosChart(){ Voltaje=r.NextDouble(), Corriente=r.NextDouble() },
                new DatosChart(){ Voltaje=r.NextDouble(), Corriente=r.NextDouble() },
                new DatosChart(){ Voltaje=r.NextDouble(), Corriente=r.NextDouble() },
                new DatosChart(){ Voltaje=r.NextDouble(), Corriente=r.NextDouble() },
                new DatosChart(){ Voltaje=r.NextDouble(), Corriente=r.NextDouble() },
                new DatosChart(){ Voltaje=r.NextDouble(), Corriente=r.NextDouble() }
            };

            return Json(datos);
        }

        public IActionResult About()
        {
            ViewBag.Name = HttpContext.Session.GetString("Test");

            return View();
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

        class DatosChart
        {
            public double Voltaje { get; set; }
            public double Corriente { get; set; }
        }
    }
}
