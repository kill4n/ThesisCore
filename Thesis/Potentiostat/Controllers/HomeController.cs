using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private IConfiguration _configuration;
        public HomeController(IRepository<User> repositoryUsers, IRepository<Device> repositoryDevices, IConfiguration configuration)
        {
            _repositoryUsers = repositoryUsers;
            _repositoryDevices = repositoryDevices;
            _configuration = configuration;
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
                        return RedirectToAction("Home", new { id = _currentUser.Id });
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
        public IActionResult Home(long id)
        {
            ViewBag.userId = id;
            IEnumerable<Device> model = _repositoryDevices.Get();
            DateTime ahora = DateTime.Now;
            foreach (var device in model)
            {
                if (device.LastUsed != null)
                {
                    if (((TimeSpan)(ahora - device.LastUsed)).TotalMinutes >= _configuration.GetValue<int>("SessionTimeout"))
                    {
                        device.LastUsed = null;
                        device.UsedBy = 0;
                        _repositoryDevices.Update(device);
                        _repositoryDevices.Save();
                    }
                }
                else
                {
                    device.UsedBy = 0;
                    _repositoryDevices.Update(device);
                    _repositoryDevices.Save();
                }
            }
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult Potentiostat(long idDevice, long idUser)
        {
            ViewBag.userId = idUser;
            ViewBag.deviceId = idDevice;

            Device model = _repositoryDevices.Get(idDevice);
            //Check if the user is logged to prevent entering 
            if ((model.UsedBy == 0) | (model.UsedBy == idUser))
            {
                model.UsedBy = idUser;
                model.LastUsed = DateTime.Now;
                _repositoryDevices.Update(model);
                _repositoryDevices.Save();
                return View(model);
            }
            else
            {
                DateTime ahora = DateTime.Now;
                if (((TimeSpan)(ahora - model.LastUsed)).TotalMinutes >= _configuration.GetValue<int>("SessionTimeout"))
                {
                    model.UsedBy = idUser;
                    model.LastUsed = DateTime.Now;
                    _repositoryDevices.Update(model);
                    _repositoryDevices.Save();
                    return View(model);
                }
                else
                {
                    return RedirectToAction("Home", new { id = idUser });
                }
            }

        }
        [HttpPost]
        public IActionResult UpdateDate(long idDevice, long idUser)
        {
            Device model = _repositoryDevices.Get(idDevice);
            model.LastUsed = DateTime.Now;
            _repositoryDevices.Update(model);
            _repositoryDevices.Save();

            return Ok("Sucess UpdateDate");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
