
using System;

namespace Practica04.Clases.Modelos
{
	/// <summary>
	/// Description of AlumnoMuyEstudioso.
	/// </summary>
	public class AlumnoMuyEstudioso: Alumno
	{
		public AlumnoMuyEstudioso(
			string nombre, int dni, int legajo, double promedio
		):base(nombre, dni, legajo, promedio){}
	
		public override int responderPregunta(int pregunta)
		{
			return pregunta % 3;
		}
	}
	
	
}
