/*
 * Created by Metodologías de Programación I
 * Activity 7. 
 * Chain of responsability and Singleton patterns 
 *
 * Antes de usar este código el alumno deberá agregar a la variable "ruta_archivo" de la clase 
 * "LectorDeArchivos" la ruta correspondiente a su equipo donde haya guardado el archvo con los datos
 * provistos por la cátedra (archivo datos.txt)
 *
 * IMPORTANTE *  
 * El código que está en este archivo SI puede modificarse para resolver la actividad solicitada
 * 
 */

using System;
using System.IO;
using Practica07;


namespace ObtencionDeDatos
{
	public class LectorDeArchivos {
		
		// El alumno deberá agregar la ruta correspondiente a su equipo donde haya guardado el archvo con los datos
		private const string ruta_archivo = "C:/Dev/Universidad/C#/Metodologias_de_programacion_Unaj2024_2C/C#/Practica 07/datos.txt";
		// --------------------------------------------------------------------------------------------------------
		
		private StreamReader lector_de_archivos;
		private Manejador manejador;
		
		
		public LectorDeArchivos():base(){
			lector_de_archivos = new StreamReader(ruta_archivo);
			//Cadena de responsabilidades
			manejador = new NumeroDesdeArchivoManejador(null);
			manejador = new StringDesdeArchivoManejador(manejador);
		}
		
		public double numeroDesdeArchivo(double max){
			return manejador.numeroDesdeArchivo(max, lector_de_archivos);
		}
		
		public string stringDesdeArchivo(int cant){
			return manejador.stringDesdeArchivo(cant, lector_de_archivos);
		}
	}
}
