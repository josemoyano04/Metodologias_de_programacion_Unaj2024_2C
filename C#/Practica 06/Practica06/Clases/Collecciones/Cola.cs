
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica06
{
	public class Cola: Coleccionable, IIterable, Ordenable, IObservado
	{
		//Atributos
		private List<Comparable> elementos = new List<Comparable>();
		private List<IObservador> observadores = new List<IObservador>();
		
		private OrdenEnAula1 ordenInicio;
		private OrdenEnAula2 ordenLlegaAlumno;
		private OrdenEnAula1 ordenAulaLlena;
		
		//Constructor
		public Cola(){}
		
		//Get
		public List<Comparable> GetElementos(){
			return elementos;
		}
		
		//Metodos
		public bool es_vacia()
		{
			
			return this.elementos.Count() <= 0? true : false;;
		}
		
		public void encolar(Comparable comp)
		{
			elementos.Insert(0, comp);
		}
		
		public Comparable desencolar()
		{
			if(!this.es_vacia())
			{
				return this.elementos[this.elementos.Count() - 1];
			}
			return null;
		}
		
		
		//Implementacion de Coleccionable
		public int cuantos()
		{
			return this.elementos.Count();
		}
		
		public Comparable minimo()
		{
			Comparable min = this.elementos[0];
			
			foreach (Comparable e in elementos)
			{
				if (e.sosMenor(min))
					min = e;
			}
			
			return min;
		}
		
		public Comparable maximo()
		{
			Comparable max = this.elementos[0];
			
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
				encolar(comp);
				ordenLlegaAlumno.ejecutar(comp);
			}
			
			//Si la coleccion tiene 40 elementos, la clase comienza
			if(cuantos() == 40) 
			{
				ordenAulaLlena.ejecutar();
			}
			else //mientras que la coleccion no tenga 40 elementos, se van a seguir agregando
			{
				encolar(comp);
				ordenLlegaAlumno.ejecutar(comp);
			}
		}
		
		//Metodo auxiliar no solicitado; utiliza polimorfismo y un nuevo parametro booleano para forzar el agregado de un elemento a la coleccion
		//este metodo no interfiere con la implementacion de el patron Command
		public void agregar(Comparable comp, bool forzarAgregado){
			if(forzarAgregado)
				encolar(comp);
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

		public IIterador crearIterador()
		{
			return new IteradorCola(this);
		}

		//Implementacion de ordenable
		public void setOrdenInicio(OrdenEnAula1 orden)
		{
			ordenInicio = orden;
		}
		public void setOrdenLlegaAlumno(OrdenEnAula2 orden)
		{
			ordenLlegaAlumno = orden;
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
