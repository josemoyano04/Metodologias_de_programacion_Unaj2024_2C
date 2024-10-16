
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica04
{
	public class Cola: Coleccionable, IIterable
	{
		//Atributos
		private List<Comparable> elementos = new List<Comparable>();
		
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
			this.encolar(comp);
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

	}
}
