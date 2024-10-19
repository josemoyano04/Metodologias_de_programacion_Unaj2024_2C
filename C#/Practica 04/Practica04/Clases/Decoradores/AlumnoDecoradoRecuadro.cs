
using System;

namespace Practica04
{	
	public class AlumnoDecoradoRecuadro: AlumnoDecorator
	{
		public AlumnoDecoradoRecuadro(IAlumnoDecorable alumno):base(alumno)
		{
			this.alumno = alumno;
		}
		
		public override string mostrarCalificacion()
		{
			string mensajePravio = alumno.mostrarCalificacion();
			string mensaje = string.Format("************************************\n" +
			                               "*  {0}\n" +
			                               "************************************",
			                               alumno.mostrarCalificacion());
			return mensaje;
		}
	}
}
