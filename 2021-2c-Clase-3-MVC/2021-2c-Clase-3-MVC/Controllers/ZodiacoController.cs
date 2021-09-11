
using _2021_2c_Clase_3_MVC.Servicios.Zodiaco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2021_2c_Clase_3_MVC.Controllers {
	public class ZodiacoController : Controller {
		// GET: ZodiacoController
		public IActionResult Index() {
			return View(SignosServicio.ObtenerTodosCronologicamente());
		}

		[HttpGet]
		public IActionResult Nuevo() {
			return View();
		}

		[HttpPost]
		public IActionResult Nuevo(Signo signo) {
			try {
				SignosServicio.Agregar(signo);
			} catch (SignoExistenteException ex) {
				ViewBag.Mensaje = ex.Message;
				return View(signo);
			}

			return Redirect("Index");
		}

		[HttpGet]
		public IActionResult NuevoConBindingAutomaticoInd() {
			return View();
		}

		[HttpPost]
		public IActionResult NuevoConBindingAutomaticoInd(string Nombre, DateTime FechaInicio, DateTime FechaFin, string Url) {
			Signo signo = new Signo() { Nombre = Nombre, FechaFin = FechaFin, FechaInicio = FechaInicio, Url = Url };
			try {
				SignosServicio.Agregar(signo);
			} catch (SignoExistenteException ex) {
				ViewBag.Mensaje = ex.Message;
				return View(signo);
			}

			return Redirect("Index");
		}


		[HttpGet]
		public IActionResult NuevoBindingManual() {
			return View();
		}

		[HttpPost]
		public IActionResult NuevoBindingManualPost() {
			Signo signo = new Signo() {
				Nombre = Request.Form["Nombre"],
				FechaFin = DateTime.Parse(Request.Form["FechaFin"]),
				FechaInicio = DateTime.Parse(Request.Form["FechaInicio"]),
				Url = Request.Form["Url"]
			};
			try {
				SignosServicio.Agregar(signo);
			} catch (SignoExistenteException ex) {
				ViewBag.Mensaje = ex.Message;
				return View(signo);
			}

			return Redirect("Index");
		}
	}
}
