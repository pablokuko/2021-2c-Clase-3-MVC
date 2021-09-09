using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2021_2c_Clase_3_MVC.Controllers
{
    public class BienvenidoController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public BienvenidoController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

    }
}
