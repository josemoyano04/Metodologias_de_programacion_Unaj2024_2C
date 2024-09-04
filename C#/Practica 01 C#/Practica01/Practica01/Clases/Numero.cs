
using System;

namespace Practica01
{
	public class Numero: Comparable
	{
		//Atributo
		private int valor;
		
		//Constructor
		public Numero(int v)
		{
			this.valor = v;
		}
		
		//Metodos
		public int getValor(){
			return this.valor;
		}
		
		//implementacion de interfaz Comparable
	
		public bool sosIgual(Comparable comp)
		{
			if (this.valor == ((Numero)comp).getValor())
				return true;
			return false;
		}
		
		public bool sosMenor(Comparable comp)
		{
			if (this.valor < ((Numero)comp).getValor())
				return true;
			return false;
		}
		
		public bool sosMayor(Comparable comp)
		{
			if (this.valor > ((Numero)comp).getValor())
				return true;
			return false;
		}
		
		//Overrides
		public override string ToString()
		{
			return string.Format("Numero\n-Valor: {0}", this.valor);
		}

	}
}
