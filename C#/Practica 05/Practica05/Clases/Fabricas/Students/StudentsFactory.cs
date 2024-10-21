﻿
using System;

namespace Practica05
{
	public abstract class StudentsFactory
	{
		protected GeneradorDeDatosAleatorios aleatorio = new GeneradorDeDatosAleatorios();
		protected LectorDeDatos teclado = new LectorDeDatos();
		
		public abstract AlumnoAdapter crearAleatorio();
		public abstract AlumnoAdapter crearPorteclado();

		public static AlumnoAdapter crearAleatorio(int opcion)
		{
			StudentsFactory fabrica = null;
			switch (opcion) {
				case 0: //Fabrica de Alumno decorado y adaptado a student
					fabrica = new DecoratedStudentsFactory();
					break;
				case 1: //Fabrica de AlumnoMuyEstudioso decorado y adaptado a student
					fabrica = new DecoratedVeryStudiousStudentsFactory();
					break;
			}
			
			return fabrica.crearAleatorio();
		}

		public static AlumnoAdapter crearPorTeclado(int opcion)
		{
			StudentsFactory fabrica = null;
			switch (opcion) {
				case 0: //Fabrica de Alumno decorado y adaptado a student
					fabrica =  new DecoratedStudentsFactory();
					break;
				case 1: //Fabrica de AlumnoMuyEstudioso decorado y adaptado a student
					fabrica = new DecoratedVeryStudiousStudentsFactory();
					break;
			}
			
			return fabrica.crearAleatorio();
		}

	}
}
