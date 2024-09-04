
using System;

namespace Practica01
{

	public class IteradorPila: Iterador
	{
		//Atriutos
		Pila pila;
		int indice;
		
		//Constructor
		public IteradorPila(Pila pila)
		{
			this.pila = pila;
			this.primero();
		}
		
		//Implementacion de Iterador
		public void primero()
		{
			this.indice = 0;
		}
		public void siguiente()
		{
			this.indice++;
		}
		public bool fin()
		{
			return pila.cuantos() >= indice;
		}
		public Comparable actual()
		{
			return this.pila.getEementos()[indice];
		}
	}
}
