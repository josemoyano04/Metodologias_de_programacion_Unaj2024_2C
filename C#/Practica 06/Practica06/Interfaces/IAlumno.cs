
using System;

namespace Practica06
{
	public interface IAlumno: Comparable
	{
		string getNombre();
		int getLegajo();
		int getCalificacion();
		void setCalificacion(int c);
		string mostrarCalificacion();
		int responderPregunta(int p);
		
		
		void prestarAtencion();
		void distraerse();
	}
	
}
