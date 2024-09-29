
using System;

namespace Practica02
{
	public class ColeccionMultiple: Coleccionable
	{
		//Atributos
		private Pila pila;
		private Cola cola;
		
		//Constructor
		public ColeccionMultiple(Pila p, Cola c)
		{
			this.pila = p;
			this.cola = c;			
		}
		
		//Implementacion de Coleccionable
		public int cuantos()
		{
			return this.pila.cuantos() + this.cola.cuantos();
		}
		
		public Comparable minimo()
		{	
			return pila.minimo().sosMenor(cola.minimo()) ? pila.minimo() : cola.minimo();
		}
		
		public Comparable maximo()
		{
			return pila.maximo().sosMayor(cola.maximo()) ? pila.maximo() : cola.maximo();
	
		}
		
		public void agregar(Comparable comp){
		}
		
		public bool contiene(Comparable comp)
		{
			return pila.contiene(comp) || cola.contiene(comp) ? true : false;
		}
		
	}
}
