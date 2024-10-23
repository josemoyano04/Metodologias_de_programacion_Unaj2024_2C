
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
			foreach (IAlumno a in hijos) {
				a.setCalificacion(c);
			}
		}

		public void prestarAtencion()
		{
			foreach (IAlumno a in hijos) {
				a.prestarAtencion();
			}
		}

		public void distraerse()
		{
			foreach (IAlumno a in hijos) {
				a.distraerse();
			}
		}

		public int responderPregunta(int p)
		{
			List<int> respuestas = respuestasDePreguntas(p);
			Diccionario contadorRespuesta = new Diccionario(); // Guarda la estructura ClaveValor:
			// (clave: respuesta, valor: cantidad de veces que aparece la respuesta)
			
			
			//Mi logica consta en usar un Diccionario implementado en anteriores actividades
			//a fin de llevar un conteo de las respuestas, colocando la respuesta concreta
			//como clave, y el contador como valor.
			
			foreach (int respuesta in respuestas) {
				Numero r = new Numero(respuesta);
				if(contadorRespuesta.contiene(r))
				{
					int cont = ((Numero)contadorRespuesta.valorDe(r)).getValor(); //Recupero el valor del contador actual
					Numero nuevoValorContador = new Numero(cont + 1); //Incremento en 1 el valor del contador
					contadorRespuesta.valorDe(r);
					
					contadorRespuesta.agregar(clave: r, valor: nuevoValorContador); //Vuelvo a guardar el valor actualizado
				}
				else
				{
					contadorRespuesta.agregar(clave: r, valor: new Numero(1)); //Si la respuesta no esta guardada en el Diccionario,
																			   //con contador = 1
				}
			}
			
			
			//Obtencion de respuesta mas votada:
			int maxContador = -1;
			int respuestaMasVotada = -1;
			
			
			IteradorDiccionario iterado = new IteradorDiccionario(contadorRespuesta);
			
			while (iterado.fin()) {
				ClaveValor cvActual = (ClaveValor)iterado.actual();
				
				int valorRespuestaActual = ((Numero)cvActual.GetClave()).getValor(); //Recupero el valor de la respuesta
				int valorContadorActual = ((Numero)cvActual.GetValor()).getValor(); //Recupero el valor del contador de la respuesta
				
				if (valorContadorActual > maxContador){
					maxContador = valorContadorActual;
					respuestaMasVotada = valorRespuestaActual;
				}
				
				iterado.siguiente();
			}
			
			
			
			return respuestaMasVotada;
		}
		private List<int> respuestasDePreguntas(int p) //Funcion auxiliar
		{
			List<int> respuestas = new List<int>();
			
			foreach (IAlumno hijo in hijos) {
				
				int respuesta = hijo.responderPregunta(p);
				respuestas.Add(respuesta);
				
				//En caso de que el hijo sea un Alumno compuesto, se realiza recursion
				if(hijo.GetType() == typeof(AlumnoCompuesto)){
					respuestas.AddRange(((AlumnoCompuesto)hijo).respuestasDePreguntas(p));
				}
			}
			return respuestas;
		}
		

		public string mostrarCalificacion()
		{
			foreach (IAlumno a in hijos) {
				a.mostrarCalificacion();
			}
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
