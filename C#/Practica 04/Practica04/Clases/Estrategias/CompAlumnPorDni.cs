namespace Practica04
{

	public class CompAlumnPorDni : IEstrategiaCompAlumno
	{
		public CompAlumnPorDni(){
		}


		//Implementacion de IEstrategiaCompAlumno
		public bool sosIgual(Alumno a, Alumno b)
		{
			return a.getDni() == b.getDni();
		}

		public bool sosMayor(Alumno a, Alumno b)
		{
			return a.getDni() > b.getDni();
		}

		public bool sosMenor(Alumno a, Alumno b)
		{
			return a.getDni() < b.getDni();
		}
	}
}
