using System;

namespace Practica01
{
	public interface EstrategiaComparacion
	{
		bool sosIgual(Alumno a, Alumno b);
		bool sosMenor(Alumno a, Alumno b);
		bool sosMayor(Alumno a, Alumno b);
	}
}
