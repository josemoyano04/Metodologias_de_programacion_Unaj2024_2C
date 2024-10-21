using System;

namespace Practica06
{

	public class CompAlumnPorPromedio : IEstrategiaCompAlumno
	{
		public CompAlumnPorPromedio(){
		}


		//Implementacion de IEstrategiaCompAlumno
		public bool sosIgual(Alumno a, Alumno b)
		{
			return a.getPromedio() == b.getPromedio();
		}

		public bool sosMayor(Alumno a, Alumno b)
		{
			return a.getPromedio() > b.getPromedio();
		}

		public bool sosMenor(Alumno a, Alumno b)
		{
			return a.getPromedio() < b.getPromedio();
		}
	}
}
