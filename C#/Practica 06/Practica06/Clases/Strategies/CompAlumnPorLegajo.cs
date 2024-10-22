using System;

namespace Practica06
{

	public class CompAlumnPorLegajo : IEstrategiaCompAlumno
	{
		public CompAlumnPorLegajo(){
		}


		//Implementacion de IEstrategiaCompAlumno
		public bool sosIgual(Alumno a, Alumno b)
		{
			return a.getLegajo() == b.getLegajo();
		}

		public bool sosMayor(Alumno a, Alumno b)
		{
			return a.getLegajo() > b.getLegajo();
		}

		public bool sosMenor(Alumno a, Alumno b)
		{
			return a.getLegajo() < b.getLegajo();
		}
	}
}
