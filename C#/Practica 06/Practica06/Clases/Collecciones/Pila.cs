
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica06
{
	public class Pila: Coleccionable, IIterable, Ordenable, IObservado
	{
		//Atributos
		private OrdenEnAula1 ordenInicio;
		private OrdenEnAula2 ordenLLegaAlumno;
		private OrdenEnAula1 ordenAulaLlena;
		
		private List<Comparable> elementos = new List<Comparable>();
		private List<IObservador> observadores = new List<IObservador>();
		
		//Constructor
		public Pila(){}
		
		//Getters
		public List<Comparable> GetElementos(){
			return this.elementos;
		}
		
		//Metodos
		public bool es_vacia()
		{
			
			return elementos.Count() <= 0;
		}
		
		public void apilar(Comparable comp)
		{
			elementos.Add(comp);
		}
		
		public Comparable desapilar()
		{
			if(!es_vacia())
			{
				return elementos[elementos.Count() - 1];
			}
			return null;
		}
		
		
		//Implementacion de Coleccionable
		public int cuantos()
		{
			return elementos.Count();
		}
		
		public Comparable minimo()
		{
			Comparable min = elementos[0];
			
			foreach (Comparable e in elementos)
			{
				if (e.sosMenor(min))
					min = e;
			}
			
			return min;
		}
		
		public Comparable maximo()
		{
			Comparable max = elementos[0];
			
			foreach (Comparable e in elementos)
			{
				if (e.sosMayor(max))
					max = e;
			}
			
			return max;
		}
		
		public void agregar(Comparable comp)
		{
			if(es_vacia()) //Si la coleccion es vacia, es porque el elemento a agregar es el primero
			{
				ordenInicio.ejecutar();
				apilar(comp);
				ordenLLegaAlumno.ejecutar(comp);
			}
			
			//Si la coleccion tiene 40 elementos, la clase comienza
			if(cuantos() == 40) 
			{
				ordenAulaLlena.ejecutar();
			}
			else //mientras que la coleccion no tenga 40 elementos, se van a seguir agregando
			{
				apilar(comp);
				ordenLLegaAlumno.ejecutar(comp);
			}
		}
		
		//Metodo auxiliar no solicitado; utiliza polimorfismo y un nuevo parametro booleano para forzar el agregado de un elemento a la coleccion
		//este metodo no interfiere con la implementacion de el patron Command
		public void agregar(Comparable comp, bool forzarAgregado){
			if(forzarAgregado)
				apilar(comp);
		}
		
		public bool contiene(Comparable comp)
		{
			foreach (Comparable e in elementos)
			{
				if(comp.sosIgual(e))
					return true;
			}
			return false;
		}
		
		//Implementacion de IIterable
		public IIterador crearIterador(){
			return new IteradorPila(this);
		}
		
		//Implementacion de ordenable
		public void setOrdenInicio(OrdenEnAula1 orden)
		{
			ordenInicio = orden;
		}
		public void setOrdenLlegaAlumno(OrdenEnAula2 orden)
		{
			ordenLLegaAlumno = orden;
		}
		public void setOrdenAulaLlena(OrdenEnAula1 orden)
		{
			ordenAulaLlena = orden;
		}

		//implementacion de IObservado 

		public void agregarObservador(IObservador observador)
		{
			observadores.Add(observador);
		}

		public void eliminarObservador(IObservador observador)
		{
			observadores.Remove(observador);
		}

		public void notificar()
		{
			foreach (IObservador o in observadores) {
				o.actualizar(this);
			}
		}
	}
}