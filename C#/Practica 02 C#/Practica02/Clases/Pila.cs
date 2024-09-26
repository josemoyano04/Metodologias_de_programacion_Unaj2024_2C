
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica02
{
	public class Pila: Coleccionable
	{
		//Atributos
		private List<Comparable> elementos = new List<Comparable>();
		
		//Constructor
		public Pila(){
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
	}
}