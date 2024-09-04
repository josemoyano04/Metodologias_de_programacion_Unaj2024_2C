
using System;

namespace Practica01
{
	public class Alumno: Persona
	{
		//Atributos
		private int legajo;
		private int promedio;
		
		//Constructor
		public Alumno(string nombre, int dni, int legajo, int promedio): base(nombre, dni)
		{
			this.legajo = legajo;
			this.promedio = promedio;
		}
		
		//Getters
		public int getLegajo(){
			return this.legajo;
		}
		
		public int getPromedio(){
			return this.promedio;
		}
		
		//Reimplementacion de Comparable
		public override bool sosIgual(Comparable comp)
		{
			if (this.legajo == ((Alumno)comp).getLegajo())
				return true;
			return false;
		}
		
		public override bool sosMenor(Comparable comp)
		{
			if (this.legajo < ((Alumno)comp).getLegajo())
				return true;
			return false;
		}
		
		public override bool sosMayor(Comparable comp)
		{
			if (this.legajo > ((Alumno)comp).getLegajo())
				return true;
			return false;
		}
		
		
		//Overrides
		public override string ToString()
		{
			return string.Format("Alumno\n-Nombre: {0}\n-Dni: {1}\n-Legajo: {2}\n-Promedio: {3}", 
			                     this.nombre, this.dni, this.legajo, this.promedio);
		}
	}
}
