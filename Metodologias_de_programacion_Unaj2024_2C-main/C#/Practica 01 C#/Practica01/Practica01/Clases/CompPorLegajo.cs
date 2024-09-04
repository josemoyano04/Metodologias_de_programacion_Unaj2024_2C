using System;

namespace Practica01
{
	public class CompPorLegajo: EstrategiaComparacion
	{
		public CompPorLegajo(){
		}
		
		
		//Implementacion de EstrategiaComparacion
		public bool sosIgual(Alumno a, Alumno b)
		{
			return a.getLegajo() == b.getLegajo();
		}
		public bool sosMenor(Alumno a, Alumno b)
		{
			return a.getLegajo() < b.getLegajo();
		}
		public bool sosMayor(Alumno a, Alumno b)
		{
			return a.getLegajo() > b.getLegajo();
		}
	
	}
}
