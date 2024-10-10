
using System;

namespace Practica03
{

	public class Profesor: Persona
	{
		//Atributos
		int antiguedad;
		
		//Constructor
		public Profesor(string nombre, int dni, int a): base(nombre, dni)
		{
			this.antiguedad = a;
		}
		
		//Getter y Setter
		public int GetAntigueda(){
			return this.antiguedad;
		}
		public void SetAntiguedad(int a){
			this.antiguedad = a;
		}
		
		//Metodos
		public void hablarALaClase(){
			Console.WriteLine("Hablando de algún tema");
		}
		public void escribirEnElPizarron(){
			Console.WriteLine("Escribiendo en el pizarrón");
		}
		
		
		//Override ToString
		public override string ToString()
		{
			return string.Format("(Profesor -Nombre: {0}, -Dni: {1}, -Antigüedad: {2})",
			                     nombre, dni, antiguedad);
		}

	}
}
