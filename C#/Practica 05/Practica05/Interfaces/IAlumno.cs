﻿
using System;

namespace Practica05
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
