
using System;

namespace Practica06
{
	//AlumnoMuyEstudiosoProxy es subclase de AlumnoProxy ya que comparte todo, excepto que uno delega en un Alumno
	//y otro en un AlumnoMuyEstudioso:
	public class AlumnoMuyEstudiosoProxy: AlumnoProxy
	{
		public AlumnoMuyEstudiosoProxy(string nombre, int dni, int legajo, int promedio) 
			:base(nombre, dni, legajo, promedio)
		{
			this.nombre = nombre;
			this.dni = dni;
			this.legajo = legajo;
			this.promedio = promedio;
		}
		
		
		//Funcion auxiliar
		protected override IAlumno obtenerAlumnoReal(){
			if(alumnoReal == null)
				alumnoReal = new AlumnoMuyEstudioso(this.nombre, this.dni, this.legajo, this.promedio);
			return alumnoReal;
		}
	}
}
