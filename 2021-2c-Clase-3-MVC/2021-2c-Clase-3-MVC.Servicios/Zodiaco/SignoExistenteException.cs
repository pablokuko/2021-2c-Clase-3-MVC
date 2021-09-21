using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2021_2c_Clase_3_MVC.Servicios.Zodiaco
{
	public class SignoExistenteException : Exception
	{
		public SignoExistenteException()
		{

		}
		public SignoExistenteException(string mensaje) : base(mensaje)
		{

		}
	}
}
