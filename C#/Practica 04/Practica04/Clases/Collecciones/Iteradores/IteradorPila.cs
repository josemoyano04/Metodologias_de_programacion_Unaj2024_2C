
using System;
using System.Collections.Generic;

namespace Practica04
{
	public class IteradorPila: IIterador
	{
		//Atributos
		private List<Comparable> elementos;
		private int indexElementoActual;
		
		//Constructor
		public IteradorPila(Pila pila)
		{
			this.elementos = pila.GetElementos();
			this.primero();
		}


		//Implementacion de iterador
		public void primero()
		{
			indexElementoActual = 0;
		}

		public void siguiente()
		{
			indexElementoActual++;
		}

		public bool fin()
		{
			return indexElementoActual >= elementos.Count;
		}

		public Comparable actual()
		{
			return elementos[indexElementoActual];
		}
	}
}
