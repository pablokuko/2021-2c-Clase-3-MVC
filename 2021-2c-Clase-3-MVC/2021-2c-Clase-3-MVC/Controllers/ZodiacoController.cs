
using _2021_2c_Clase_3_MVC.Servicios.Zodiaco;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _2021_2c_Clase_3_MVC.Controllers
{
	public class ZodiacoController : Controller
	{
		// GET: ZodiacoController
		public IActionResult Index()
		{
			if (TempData["SignoEliminado"] != null)
				ViewBag.SignoEliminado = TempData["SignoEliminado"].ToString();

			if (TempData["ErrorAlEliminarSigno"] != null)
				ViewBag.ErrorAlEliminarSigno = TempData["ErrorAlEliminarSigno"].ToString();

			return View(SignosServicio.ObtenerTodosCronologicamente());
		}

		[HttpGet]
		public IActionResult Nuevo()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Nuevo(Signo signo)
		{
			try
			{
				SignosServicio.Agregar(signo);
			}
			catch (SignoExistenteException ex)
			{
				ViewBag.Mensaje = ex.Message;
				return View(signo);
			}

			return Redirect("Index");
		}

		[HttpGet]
		public IActionResult NuevoConBindingAutomaticoInd()
		{
			return View();
		}

		[HttpPost]
		public IActionResult NuevoConBindingAutomaticoInd(string Nombre, DateTime FechaInicio, DateTime FechaFin, string Url)
		{
			Signo signo = new Signo() { Nombre = Nombre, FechaFin = FechaFin, FechaInicio = FechaInicio, Url = Url };
			try
			{
				SignosServicio.Agregar(signo);
			}
			catch (SignoExistenteException ex)
			{
				ViewBag.Mensaje = ex.Message;
				return View(signo);
			}

			return Redirect("Index");
		}


		[HttpGet]
		public IActionResult NuevoBindingManual()
		{
			return View();
		}

		[HttpPost]
		public IActionResult NuevoBindingManualPost()
		{
			Signo signo = new Signo()
			{
				Nombre = Request.Form["Nombre"],
				FechaFin = DateTime.Parse(Request.Form["FechaFin"]),
				FechaInicio = DateTime.Parse(Request.Form["FechaInicio"]),
				Url = Request.Form["Url"]
			};
			try
			{
				SignosServicio.Agregar(signo);
			}
			catch (SignoExistenteException ex)
			{
				ViewBag.Mensaje = ex.Message;
				return View(signo);
			}

			return Redirect("Index");
		}

		[Route("/zodiaco/cualesmisigno/{day:int}/{month:int}")]
		public IActionResult CualEsMiSigno(int day, int month)
		{
			DateTime date;

			if (!DateTime.TryParse($"{day}/{month}/2021", out date))
			{
				ViewBag.SignError = "La fecha ingresada no es valida, intente nuevamente.";
				return View();
			}

			return View(SignosServicio.GetSignoBy(date));
		}

		public IActionResult Eliminar(int id)
		{
			if (SignosServicio.EliminarSignoPor(id))
			{
				TempData["SignoEliminado"] = "Signo eliminado correctamente.";
			}
			else
			{
				TempData["ErrorAlEliminarSigno"] = "Ocurrio un error al intentar eliminar el signo, intente nuevamente.";
			}

			return Redirect("/zodiaco");
		}
	}
}
