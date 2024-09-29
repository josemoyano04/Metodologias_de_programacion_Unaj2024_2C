
using System;
using System.Collections.Generic;

namespace Practica02
{
	public class IteradorConjunto: IIterador
	{
		//Atributos
		private List<Comparable> elementos;
		private int indexElementoActual;
		
		//Constructor
		public IteradorConjunto(Conjunto conjunto)
		{
			this.elementos = conjunto.GetElementos();
			primero();
		}

		//implementacion de IIterador

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
			return indexElementoActual>= elementos.Count;
		}

		public Comparable actual()
		{
			return elementos[indexElementoActual];
		}

	}
}
