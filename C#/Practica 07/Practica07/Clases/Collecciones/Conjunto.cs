using System;
using System.Collections.Generic;

namespace Practica07
{
	public class Conjunto : Coleccionable, IIterable, Ordenable, IObservado
	{
		//Atributos
		private List<Comparable> elementos = new List<Comparable>();
		private List<IObservador> observadores = new List<IObservador>();
		
		private OrdenEnAula1 ordenInicio = null;
		private OrdenEnAula2 ordenLlegaAlumno = null;
		private OrdenEnAula1 ordenAulaLlena = null;
		
		
		//Constructor
		public Conjunto(){}
		
		//Get
		public List<Comparable> GetElementos(){
			return elementos;
		}
		
		//Metodos Solicitados
		public void agregar(Comparable comp) //Implementacion de Coleccionable
		{
			if(!this.pertenece(comp)) {
				if(cuantos() == 0 && ordenInicio != null && ordenLlegaAlumno != null) //Si la coleccion es vacia, es porque el elemento a agregar es el primero
				{
					ordenInicio.ejecutar();
					elementos.Add(comp);
					ordenLlegaAlumno.ejecutar(comp);
				}
				
				//Si la coleccion tiene 40 elementos, la clase comienza
				if(cuantos() == 40 && ordenAulaLlena != null)
				{
					ordenAulaLlena.ejecutar();
				}
				if(cuantos() > 40 && ordenLlegaAlumno != null) //mientras que la coleccion no tenga 40 elementos, se van a seguir agregando
				{
					elementos.Add(comp);
					ordenLlegaAlumno.ejecutar(comp);
				}
			}
		}
		
		//Metodo auxiliar no solicitado; utiliza polimorfismo y un nuevo parametro booleano para forzar el agregado de un elemento a la coleccion
		//este metodo no interfiere con la implementacion de el patron Command
		public void agregar(Comparable comp, bool forzarAgregado){
			
			if(forzarAgregado){
				if(!pertenece(comp))
					elementos.Add(comp);
			}
		}
		
		public bool pertenece(Comparable comp)
		{
			return contiene(comp);
		}
		
		
		
		//Implementacion de Coleccionable
		public int cuantos()
		{
			return elementos.Count;
		}
		
		public Comparable minimo()
		{
			Comparable min = elementos[0];
			
			foreach (Comparable e in elementos)
			{
				if (e.sosMenor(min)) {
					min = e;
				}
			}
			return min;
		}
		
		public Comparable maximo()
		{
			Comparable max = elementos[0];
			
			foreach (Comparable e in elementos)
			{
				if (e.sosMayor(max)) {
					max = e;
				}
			}
			return max;
		}
		
		public bool contiene(Comparable comp)
		{
			foreach (Comparable e in elementos) {
				if (comp.sosIgual(e)) {
					return true;
				}
			}
			return false;
		}
		
		//Implementacion de IIterable
		public IIterador crearIterador(){
			return new IteradorConjunto(this);
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
