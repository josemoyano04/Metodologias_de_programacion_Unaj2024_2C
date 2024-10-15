
using System;


namespace Practica03
{

	public class AlumnoFavorito: Alumno
	{
		
		
		public AlumnoFavorito(string nombre, int dni, int legajo, double promedio): base(nombre, dni, legajo, promedio){
			this.estrategiaComp = new CompAlumnPorLegajo();
		}
		
		public override void distraerse(){
			Console.WriteLine("“Yo nunca me distraigo, siempre presto atención");
		}
		
		//Reimplementacion de IObservado
		public override void actualizar(IObservado o)
		{
			notificar();
		}
		
		
		
		
	}
}
