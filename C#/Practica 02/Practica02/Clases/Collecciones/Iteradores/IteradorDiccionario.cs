
using System;
using System.Collections.Generic;

namespace Practica02
{
	public class IteradorDiccionario: IIterador
	{
		//Atributos
		private List<Comparable> elementos;
		private int indexElementoActual;
		
		public IteradorDiccionario(Diccionario diccionario)
		{
			this.elementos = (diccionario.GetElementos()).GetElementos();
			primero();
		}

		//Implementacion de IIterador
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
