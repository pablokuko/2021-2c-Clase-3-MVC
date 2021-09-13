using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_2c_Clase_3_MVC.Servicios.Zodiaco
{
    public class SignosServicio
    {
        private static List<Signo> Lista { get; set; } = new List<Signo>()
        {
            /*
             * Aries, Tauro, Géminis, Cáncer, Leo, Virgo, Libra, Escorpión, Sagitario, Capricornio, Acuario y Piscis
             * */
            new Signo(){ Id = 1,Nombre = "Capricornio", FechaInicio = new DateTime(2020, 12, 22), FechaFin = new DateTime(2021, 1, 20), Url = "https://es.wikipedia.org/wiki/Capricornio_(Constelaci%C3%B3n)"},
            new Signo(){ Id = 2,Nombre = "Acuario", FechaInicio = new DateTime(2021, 1, 21), FechaFin = new DateTime(2021, 2, 18), Url = "https://es.wikipedia.org/wiki/Acuario_(constelaci%C3%B3n)"},
            new Signo(){ Id = 3,Nombre = "Piscis", FechaInicio = new DateTime(2021, 2, 19), FechaFin = new DateTime(2021, 3, 20), Url = "https://es.wikipedia.org/wiki/Piscis_(constelaci%C3%B3n)"},
        };


        public static List<Signo> ObtenerTodosCronologicamente()
        {
            return Lista.OrderBy(o=> o.FechaInicio).ToList();
        }

        public static void Agregar(Signo signo)
        {
            if (Lista.Any(o => string.Equals(o.Nombre?.Trim(), signo.Nombre?.Trim(), StringComparison.OrdinalIgnoreCase)))
                throw new SignoExistenteException($"Ya existe un signo con el nombre {signo.Nombre}");

            signo.Id = Lista.Max(o => o.Id) + 1;

            Lista.Add(signo);
        }

        public static void Borrar(Signo signo) 
        {          
            Lista.Remove(signo);           
        }
    }
}
