
using System;

namespace Practica05
{
	public interface IAlumno: Comparable
	{
		string getNombre();
		int getLegajo();
  		int getCalificacion();
		void setCalificacion(int c);
		
		void prestarAtencion();
		void distraerse();
		int responderPregunta(int p);
		string mostrarCalificacion();
	}
	
}
