
using System;

namespace Practica05
{
	public class AlumnoDecoradoSecuanciaNumerica : AlumnoDecorator
	{
		private static int contador = 1;

		public AlumnoDecoradoSecuanciaNumerica(IAlumno alumno) : base(alumno)
		{
			this.alumno = alumno;
		}

		public override string mostrarCalificacion()
		{
			string mensajePrevio = alumno.mostrarCalificacion();
			string mensaje = String.Format("{0}) {1}", contador, mensajePrevio);
			contador++;

			return mensaje;

		}

		public static void resetContador()
		{
			contador = 1;
		}
	}
}
