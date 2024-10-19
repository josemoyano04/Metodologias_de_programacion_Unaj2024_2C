
using System;

namespace Practica04
{
	public class AlumnoDecoradoLegajo: AlumnoDecorator
	{
		public AlumnoDecoradoLegajo(IAlumnoDecorable alumno): base(alumno)
		{
			this.alumno = alumno;
		}
		
		public override string mostrarCalificacion()
		{
			string mensajePrevio = this.alumno.mostrarCalificacion();
			string mensaje = string.Format("{0}({1})     {2}", alumno.getNombre(), alumno.getLegajo(), alumno. getCalificacion());
			return mensaje;
		}
	}
}
