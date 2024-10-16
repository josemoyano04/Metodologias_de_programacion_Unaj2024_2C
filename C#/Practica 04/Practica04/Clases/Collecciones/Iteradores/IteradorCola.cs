
using System;
using System.Collections.Generic;

namespace Practica04
{
	public class IteradorCola: IIterador
	{
		//Atributos
		private List<Comparable> elementos;
		private int indexElementoActual;
		
		//Constructor
		public IteradorCola(Cola cola)
		{
			this.elementos = cola.GetElementos();
			this.primero();
			
		}

		// Implementacion de IIterador

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
