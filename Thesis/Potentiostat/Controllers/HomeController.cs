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
using Thesis.Models.Data;
using Thesis.Repository;

namespace Potentiostat.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<User> _repositoryUsers;
        private readonly IRepository<Device> _repositoryDevices;
        private User _currentUser;
        public HomeController(IRepository<User> repositoryUsers, IRepository<Device> repositoryDevices)
        {
            _repositoryUsers = repositoryUsers;
            _repositoryDevices = repositoryDevices;

            var users = _repositoryUsers.Get();
            if (!users.Any())
            {
                User user = new User()
                {
                    UserName = "csegura",
                    Password = "12345",
                    Email = "cc.segura@uniandes.edu.co",
                    Active = true,
                    State = true
                };
                _repositoryUsers.Add(user);
                _repositoryUsers.Save();
            }
            var devices = _repositoryDevices.Get();
            if (!devices.Any())
            {
                Device device = new Device()
                {
                    Name = "Potentiostat",
                    State = 0,
                    UsedBy = 0
                };
                _repositoryDevices.Add(device);
                _repositoryDevices.Save();
            }

        }

        public IActionResult Index()
        {
            return View(new UserViewModel());
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in _repositoryUsers.Get()
                            where (u.UserName == model.UserName)
                            select u);
                if (user.Any())
                {
                    ViewBag.ErrorMessage = "El nombre de usuario ya esta ocupado";
                    return View("Register", model);
                }
                else
                {
                    model.Active = true;
                    _repositoryUsers.Add(model);
                    _repositoryUsers.Save();
                    return View("Index");
                }
            }
            else
            {
                ViewBag.ErrorMessage = "Los datos no son validos";
                return View("Register");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = (from u in _repositoryUsers.Get()
                            where (u.UserName == model.User) && (u.Password == model.Password)
                            select u);
                if (user.Any())
                {
                    if (user.FirstOrDefault().Active)
                    {
                        _currentUser = user.FirstOrDefault();
                        return Redirect("Home");
                    }
                    else
                    {
                        _currentUser = null;
                        ViewBag.ErrorMessage = "El usuario no se encuentra activo.";
                        return View("Index", model);
                    }
                }
                else
                {
                    _currentUser = null;
                    ViewBag.ErrorMessage = "El usuario o contraseña son incorrectos";
                    return View("Index", model);
                }
            }
            else
            {
                _currentUser = null;
                ViewBag.ErrorMessage = "El usuario o contraseña son incorrectos";
                return View("Index");
            }
        }
        [HttpGet]
        public IActionResult Home()
        {
            ViewBag.userId = _currentUser?.Id;

            IEnumerable<Device> model = _repositoryDevices.Get();
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Potentiostat(Device model)
        {

            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
