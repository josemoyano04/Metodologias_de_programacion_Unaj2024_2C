using System;
using System.Collections.Generic;

namespace Practica04
{
	public class Conjunto : Coleccionable, IIterable
	{
		//Atributos
		private List<Comparable> elementos = new List<Comparable>();
		
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
	}
}
