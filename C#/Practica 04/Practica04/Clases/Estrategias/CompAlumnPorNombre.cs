using System;

namespace Practica04
{
	public class CompAlumnPorNombre: IEstrategiaCompAlumno
	{
		public CompAlumnPorNombre(){
		}


		public bool sosIgual(Alumno a, Alumno b)
		{
			return a.getNombre() == b.getNombre();
		}

		public bool sosMayor(Alumno a, Alumno b)
		{
			return a.getNombre().Length > b.getNombre().Length;
		}

		public bool sosMenor(Alumno a, Alumno b)
		{
			return a.getNombre().Length < b.getNombre().Length;
		}

	}
}
