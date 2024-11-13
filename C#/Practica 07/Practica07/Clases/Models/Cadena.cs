
using System;

namespace Practica07
{

	public class Cadena: Comparable
	{
		string valor;
		
		public Cadena(string s)
		{
			this.valor = s;
		}
		//Getters y Setters
		public string getValor(){
			return this.valor;
		}
		public void setValor(string s){
			this.valor = s;
		}

		//Implementacion de Comparable

		public bool sosIgual(Comparable comp)
		{
			return this.valor == ((Cadena)comp).getValor();
		}
		
		public bool sosMenor(Comparable comp)
		{
			return this.valor.Length < ((Cadena)comp).getValor().Length;
		}

		public bool sosMayor(Comparable comp)
		{
			return this.valor.Length > ((Cadena)comp).getValor().Length;
		}
		
		//Override To String
		public override string ToString()
		{
			return string.Format("{0}", valor);
		}

	}
}