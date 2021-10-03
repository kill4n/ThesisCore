using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Potentiostat.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Potentiostat.Controllers
{
    public class HomeController : Controller
    {
        private List<UserViewModel> _usuarios = new List<UserViewModel>()
        {
            new UserViewModel(){
            User="csegura",
            Password="12345"
            }
        };
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View(new UserViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in _usuarios
                            where (u.User == model.User) && (u.Password == model.Password)
                            select u);
                if (user.Any())
                {
                    return Redirect("Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "El usuario o contraseña son incorrectos";
                    return View("Index", model);
                }
            }
            else
            {
                ViewBag.ErrorMessage = "El usuario o contraseña son incorrectos";
                return View("Index");
            }
        }

        public IActionResult Home()
        {

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Potentiostat()
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
