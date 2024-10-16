
using System;


namespace Practica04
{

	public class AlumnoFavorito: Alumno
	{
		

		public AlumnoFavorito(string nombre, int dni, int legajo, double promedio): base(nombre, dni, legajo, promedio){
			this.estrategiaComp = new CompAlumnPorLegajo();
		}
		
		public override void distraerse(){
			Console.WriteLine("Alumno Favorito: Yo nunca me distraigo, siempre presto atención");
		}
		
		public override void actualizar(IObservado o)
		{
			if (o is Profesor) {
				if (((Profesor)o).esta_hablando())
					this.prestarAtencion();
				else {
					this.distraerse();
				}
			}
			if(o is Alumno){
				this.notificar();
			}
		}
	}
}
