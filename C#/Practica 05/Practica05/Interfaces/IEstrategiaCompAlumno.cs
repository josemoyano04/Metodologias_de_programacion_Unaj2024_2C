using System;

namespace Practica05
{
	
	public interface IEstrategiaCompAlumno{
		
		//Metodos
		bool sosIgual(Alumno a, Alumno b);
		bool sosMayor(Alumno a, Alumno b);
		bool sosMenor(Alumno a, Alumno b);
	}
}
