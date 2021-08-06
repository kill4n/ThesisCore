using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PotentiostatApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.IO.Ports;

namespace PotentiostatApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        SerialPort _serialPort;

        public HomeController(ILogger<HomeController> logger, SerialPort serialPort)
        {
            _logger = logger;
            _serialPort = serialPort;
            string puerto = SerialPort.GetPortNames().FirstOrDefault();
            _serialPort.PortName = puerto;
            _serialPort.DataReceived += _serialPort_DataReceived;
        }

        private void _serialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            if (_serialPort.IsOpen)
            {
                //ViewBag.Data = _serialPort.ReadLine();
            }
        }
        [HttpPost]
        public ActionResult UpdatePartial()
        {
            DataModel modelo = new DataModel()
            {
                Data = "Hola Partial"
            }; 
            return PartialView("_partialUART", modelo);
        }

        public IActionResult Index()
        {
            ViewBag.Puertos = SerialPort.GetPortNames();

            if (!_serialPort.IsOpen)
            {
                _serialPort.Open();
            }

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
    }
}
