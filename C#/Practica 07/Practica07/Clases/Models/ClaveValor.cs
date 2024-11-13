
using System;

namespace Practica07
{

	public class ClaveValor: Comparable
	{
		//Atributos
		private Comparable clave;
		private Comparable valor;
		
		//Constructor
		public ClaveValor(Comparable clave, Comparable valor)
		{
			this.clave = clave;
			this.valor = valor;
		}
		
		//Getters y Setters
		public Comparable GetClave(){
			return clave;
		}
		
		
		public Comparable GetValor(){
			return valor;
		}
		
		public void SetValor(Comparable nuevoValor){
			valor = nuevoValor;
			
		}
		
		
		//Implementacion de Comparable
		public bool sosIgual(Comparable clave)
		{
			return this.clave.sosIgual(clave);
		}
		public bool sosMenor(Comparable clave)
		{
			return this.clave.sosMenor(clave);
		}
		public bool sosMayor(Comparable clave)
		{
			return this.clave.sosMayor(clave);
		}
		
		//Override de ToString
		public override string ToString()
		{
			return string.Format("(Clave: {0}, Valor: {1})", clave, valor);
		}

	}
}
