
using System;

namespace Practica04
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
			try {
				if (this.valor == ((Numero)comp).getValor())
				return true;
			} catch (InvalidCastException) {}
			
			return false;
		}
		
		public bool sosMenor(Comparable comp)
		{
			return this.valor < ((Numero)comp).getValor();
		}
		
		public bool sosMayor(Comparable comp)
		{
			return this.valor > ((Numero)comp).getValor();
		}
		
		//Overrides
		public override string ToString()
		{
			return string.Format("(Numero -valor: {0})", this.valor);
		}

	}
}
