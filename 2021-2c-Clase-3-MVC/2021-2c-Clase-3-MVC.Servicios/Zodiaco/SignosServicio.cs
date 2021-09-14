using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_2c_Clase_3_MVC.Servicios.Zodiaco {
	public class SignosServicio {
		private static List<Signo> Lista { get; set; } = new List<Signo>() {
            /*
             * Aries, Tauro, Géminis, Cáncer, Leo, Virgo, Libra, Escorpión, Sagitario, Capricornio, Acuario y Piscis
             * */
            new Signo(){ Id = 1,Nombre = "Capricornio", FechaInicio = new DateTime(2020, 12, 22), FechaFin = new DateTime(2021, 1, 20), Url = "https://es.wikipedia.org/wiki/Capricornio_(Constelaci%C3%B3n)"},
			new Signo(){ Id = 2,Nombre = "Acuario", FechaInicio = new DateTime(2021, 1, 21), FechaFin = new DateTime(2021, 2, 18), Url = "https://es.wikipedia.org/wiki/Acuario_(constelaci%C3%B3n)"},
			new Signo(){ Id = 3,Nombre = "Piscis", FechaInicio = new DateTime(2021, 2, 19), FechaFin = new DateTime(2021, 3, 20), Url = "https://es.wikipedia.org/wiki/Piscis_(constelaci%C3%B3n)"},
		};

		private static List<Signo> ListaCompleta { get; set; } = new List<Signo>() {
			new Signo(){ Id = 1, Nombre = "Capricornio", FechaInicio = new DateTime(2020, 12, 22), FechaFin = new DateTime(2021, 1, 20), Url = "https://es.wikipedia.org/wiki/Capricornio_(Constelaci%C3%B3n)"},
			new Signo(){ Id = 2, Nombre = "Acuario", FechaInicio = new DateTime(2021, 1, 21), FechaFin = new DateTime(2021, 2, 18), Url = "https://es.wikipedia.org/wiki/Acuario_(constelaci%C3%B3n)"},
			new Signo(){ Id = 3, Nombre = "Piscis", FechaInicio = new DateTime(2021, 2, 19), FechaFin = new DateTime(2021, 3, 20), Url = "https://es.wikipedia.org/wiki/Piscis_(constelaci%C3%B3n)"},
			new Signo(){ Id = 4, Nombre = "Aries", FechaInicio = new DateTime(2020, 3, 21), FechaFin = new DateTime(2021, 4, 20), Url = "https://es.wikipedia.org/wiki/Aries_(constelaci%C3%B3n)"},
			new Signo(){ Id = 5, Nombre = "Tauro", FechaInicio = new DateTime(2021, 4, 21), FechaFin = new DateTime(2021, 5, 20), Url = "https://es.wikipedia.org/wiki/Tauro_(constelaci%C3%B3n)"},
			new Signo(){ Id = 6, Nombre = "Geminis", FechaInicio = new DateTime(2021, 5, 21), FechaFin = new DateTime(2021, 6, 21), Url = "https://es.wikipedia.org/wiki/Gemini_(constelaci%C3%B3n)"},
			new Signo(){ Id = 7, Nombre = "Cancer", FechaInicio = new DateTime(2020, 6, 22), FechaFin = new DateTime(2021, 7, 22), Url = "https://es.wikipedia.org/wiki/C%C3%A1ncer_(constelaci%C3%B3n)"},
			new Signo(){ Id = 8, Nombre = "Leo", FechaInicio = new DateTime(2021, 7, 23), FechaFin = new DateTime(2021, 8, 22), Url = "https://es.wikipedia.org/wiki/Leo_(constelaci%C3%B3n)"},
			new Signo(){ Id = 9, Nombre = "Virgo", FechaInicio = new DateTime(2021, 8, 23), FechaFin = new DateTime(2021, 9, 22), Url = "https://es.wikipedia.org/wiki/Virgo_(constelaci%C3%B3n)"},
			new Signo(){ Id = 10, Nombre = "Libra", FechaInicio = new DateTime(2020, 9, 23), FechaFin = new DateTime(2021, 10, 22), Url = "https://es.wikipedia.org/wiki/Libra_(constelaci%C3%B3n)"},
			new Signo(){ Id = 11, Nombre = "Escorpio", FechaInicio = new DateTime(2021, 10, 23), FechaFin = new DateTime(2021, 11, 22), Url = "https://es.wikipedia.org/wiki/Escorpio_(constelaci%C3%B3n)"},
			new Signo(){ Id = 12, Nombre = "Sagitario", FechaInicio = new DateTime(2021, 11, 23), FechaFin = new DateTime(2021, 12, 21), Url = "https://es.wikipedia.org/wiki/Sagitario_(constelaci%C3%B3n)"},
		};

		public static List<Signo> ObtenerTodosCronologicamente() {
			return Lista.OrderBy(o => o.FechaInicio).ToList();
		}

		public static void Agregar(Signo signo) {
			if (Lista.Any(o => string.Equals(o.Nombre?.Trim(), signo.Nombre?.Trim(), StringComparison.OrdinalIgnoreCase)))
				throw new SignoExistenteException($"Ya existe un signo con el nombre {signo.Nombre}");

			signo.Id = Lista.Max(o => o.Id) + 1;

			Lista.Add(signo);
		}

		public static Signo GetSignoBy(DateTime date) {
			Signo Result = new Signo();

			foreach (Signo Signo in ListaCompleta) {
				if ((Signo.FechaInicio.Month == date.Month && date.Day >= Signo.FechaInicio.Day)
					|| (Signo.FechaFin.Month == date.Month && date.Day <= Signo.FechaFin.Day)) {
					Result = Signo;
				}
			}

			return Result;
		}

		public static bool DeleteSignBy(int id) {
			return Lista.Remove(Lista.Find(sign => sign.Id == id));
		}
	}
}
