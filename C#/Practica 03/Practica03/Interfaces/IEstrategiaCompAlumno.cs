using System;

namespace Practica03
{
	
	public interface IEstrategiaCompAlumno{
		
		//Metodos
		bool sosIgual(Alumno a, Alumno b);
		bool sosMayor(Alumno a, Alumno b);
		bool sosMenor(Alumno a, Alumno b);
	}
}
