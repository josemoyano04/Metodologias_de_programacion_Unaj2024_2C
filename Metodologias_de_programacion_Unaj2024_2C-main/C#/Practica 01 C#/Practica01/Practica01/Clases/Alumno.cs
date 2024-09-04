using System;

namespace Practica01
{
	public class Alumno: Persona
	{
		//Atributos
		private int legajo;
		private int promedio;
		private EstrategiaComparacion estrategiaComp;
		
		//Constructor
		public Alumno(string nombre, int dni, int legajo, int promedio): base(nombre, dni)
		{
			this.legajo = legajo;
			this.promedio = promedio;
			this.estrategiaComp = new CompPorLegajo();
		}
		
		//Getters
		public int getLegajo(){
			return this.legajo;
		}
		
		public int getPromedio(){
			return this.promedio;
		}
		
		//Setters
		public void setEstrategiaComp(EstrategiaComparacion e){
			this.estrategiaComp = e;
		}
		
		//Reimplementacion de Comparable
		public override bool sosIgual(Comparable comp)
		{
			return this.estrategiaComp.sosIgual(this, (Alumno)comp);
		}
		
		public override bool sosMenor(Comparable comp)
		{
			return this.estrategiaComp.sosMenor(this, (Alumno)comp);
		}
		
		public override bool sosMayor(Comparable comp)
		{
			return this.estrategiaComp.sosMayor(this, (Alumno)comp);
		}
		
		
		//Overrides
		public override string ToString()
		{
			return string.Format("Alumno\n-Nombre: {0}\n-Dni: {1}\n-Legajo: {2}\n-Promedio: {3}", 
			                     this.nombre, this.dni, this.legajo, this.promedio);
		}
	}
}
