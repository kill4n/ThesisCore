using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebThesis.Models;

namespace WebThesis.Controllers
{
    public class PotentiostatController : Controller
    {
        public IActionResult Index()
        {
            PotenciostatoModel model = new PotenciostatoModel();
            model.DataPotentiostat = new List<Data>()
            {
                new Data()
                {
                    IdUser=1,
                    DateRun= DateTime.Now,
                    Description="Primera prueba"
                }
            };
            return View(model);
        }
    }
}
