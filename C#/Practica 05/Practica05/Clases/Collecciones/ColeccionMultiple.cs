
using System;

namespace Practica05
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
		
		//Getters y Setter
		public Coleccionable getPila(){
			return this.pila;
		}
		public Coleccionable getCola(){
			return this.cola;
		}
		
		public void setPila(Pila p){
			this.pila = p;
		}
		public void setCola(Cola c){
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
			this.pila.agregar(comp);
			this.cola.agregar(comp);
		}
		
		public bool contiene(Comparable comp)
		{
			return pila.contiene(comp) || cola.contiene(comp) ? true : false;
		}
		
		//Implementacion de ordenable
		public void setOrdenInicio(OrdenEnAula1 orden)
		{
			throw new NotImplementedException();
		}
		public void setOrdenLlegaAlumno(OrdenEnAula2 orden)
		{
			throw new NotImplementedException();
		}
		public void setOrdenAulaLlena(OrdenEnAula1 orden)
		{
			throw new NotImplementedException();
		}
	}
}
