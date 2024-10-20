
using System;

namespace Practica04
{
	public interface IAlumno
	{
		string getNombre();
		int getLegajo();
		int getCalificacion();
		void setCalificacion(int c);
		int responderPregunta(int p);
		string mostrarCalificacion();
	}
	
}
