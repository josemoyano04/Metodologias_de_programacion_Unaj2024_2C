
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Practica06
{
	public class AlumnoCompuesto: IAlumno
	{
		private List<IAlumno> hijos = new List<IAlumno>();
		
		public AlumnoCompuesto(){}
		
		public void agregarHijo(IAlumno hijo){
			hijos.Add(hijo);
		}
		
		public void eliminarHijo(IAlumno hijo){
			hijos.Remove(hijo);
		}
		
		#region IAlumno implementation

		public string getNombre()
		{
			List<string> nombres = new List<string>();
			
			foreach (IAlumno hijo in hijos){
				nombres.Add(hijo.getNombre());
			}
			
			return string.Join(", ", nombres);
		}

		public int getLegajo()
		{
			throw new NotImplementedException();
		}

		public int getCalificacion()
		{
			throw new NotImplementedException();
		}

		public void setCalificacion(int c)
		{
			throw new NotImplementedException();
		}

		public void prestarAtencion()
		{
			throw new NotImplementedException();
		}

		public void distraerse()
		{
			throw new NotImplementedException();
		}

		public int responderPregunta(int p)
		{
			List<int> respuestas = respuestasDePreguntas();
			Diccionario contadorRespuesta = new Diccionario();
			
			
			//Mi logica consta en usar un Diccionario implementado en anteriores actividades
			//a fin de llevar un conteo de las respuestas, colocando la respuesta concreta
			//como clave, y el contador como valor.
			
			foreach (int respuesta in respuestas) {
				if(contadorRespuesta.contiene(new Numero(respuesta)))
				{
					 
				}
			}
			
			return max; //Falta logica para identificar el mayor
		}
		public List<int> respuestasDePreguntas(int p) //Funcion auxiliar
		{
			List<int> respuestas = new List<int>();
			
			foreach (IAlumno hijo in hijos) {
				
				int respuesta = hijo.responderPregunta(p);
				respuestas.Add(respuesta);
				
				//En caso de que el hijo sea un Alumno compuesto, se realiza recursion
				if(hijo.GetType == typeof(AlumnoCompuesto)){ 
					respuestas.AddRange(((AlumnoCompuesto)hijo).respuestasDePreguntas(p));
				}
			}
			return respuestas;
		}
		

		public string mostrarCalificacion()
		{
			throw new NotImplementedException();
		}

		#endregion

		#region Comparable implementation

		public bool sosIgual(Comparable comp)
		{
			throw new NotImplementedException();
		}

		public bool sosMenor(Comparable comp)
		{
			throw new NotImplementedException();
		}

		public bool sosMayor(Comparable comp)
		{
			throw new NotImplementedException();
		}

		#endregion
	}
}
