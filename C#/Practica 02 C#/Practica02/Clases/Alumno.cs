
using System;
using System.Runtime.InteropServices;

namespace Practica02
{
	public class Alumno: Persona
	{
		//Atributos
		private int legajo;
		private int promedio;
		private IEstrategiaCompAlumno estrategiaComp;
		
		//Constructor
		public Alumno(string nombre, int dni, int legajo, int promedio): base(nombre, dni)
		{
			this.legajo = legajo;
			this.promedio = promedio;
			this.estrategiaComp = new CompAlumnPorLegajo();
		}
		
		//Getters
		public int getLegajo(){
			return legajo;
		}
		
		public int getPromedio(){
			return promedio;
		}
		
		//Reimplementacion de Comparable
		public override bool sosIgual(Comparable comp)
		{
			try {
				return estrategiaComp.sosIgual(this, (Alumno)comp);
			} catch (InvalidCastException) {
				return false;
			}
		}
		
		public override bool sosMenor(Comparable comp)
		{
			return estrategiaComp.sosMenor(this, (Alumno)comp);
		}
		
		public override bool sosMayor(Comparable comp)
		{
			return estrategiaComp.sosMayor(this, (Alumno)comp);
		}
		
		
		//Overrides
		public override string ToString()
		{
			return string.Format("Alumno\n-Nombre: {0}\n-Dni: {1}\n-Legajo: {2}\n-Promedio: {3}",
			                     nombre, dni, legajo, promedio);
		}
	}
}
