
using System;

namespace Practica04
{
	public abstract class AlumnoDecorator: IAlumnoDecorable
	{
		protected IAlumnoDecorable alumno;
		
		protected AlumnoDecorator(IAlumnoDecorable alumno)
		{
			this.alumno = alumno;
		}

		public string getNombre()
		{
			return this.alumno.getNombre();
		}
		public int getLegajo()
		{
			return this.alumno.getLegajo();
		}
		public int getCalificacion()
		{
			return this.alumno.getCalificacion();
		}
		
		public virtual string mostrarCalificacion()
		{
			return this.alumno.mostrarCalificacion();
		}
		
	}
}
