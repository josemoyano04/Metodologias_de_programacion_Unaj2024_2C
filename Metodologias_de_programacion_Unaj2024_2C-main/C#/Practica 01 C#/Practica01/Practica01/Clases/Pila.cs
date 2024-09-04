﻿
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica01
{
	public class Pila: Coleccionable, Iterable
	{
		//Atributos
		private List<Comparable> elementos = new List<Comparable>();
		
		//Constructor
		public Pila(){
		}
		
		//Getters
		public List<Comparable> getEementos(){
			return this.elementos;
		}
		
		//Metodos
		public bool es_vacia()
		{
			
			return this.elementos.Count() <= 0;
		}
		
		public void apilar(Comparable comp)
		{
			elementos.Add(comp);
		}
		
		public Comparable desapilar()
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
			this.apilar(comp);
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
		
		//Implementacion de Iterable
		public Iterador crearIterador()
		{
			return new IteradorPila(this);
		}

	}
}
