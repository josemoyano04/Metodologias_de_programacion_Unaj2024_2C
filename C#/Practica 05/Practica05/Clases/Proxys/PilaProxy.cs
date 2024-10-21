
using System;

namespace Practica05
{
	public class PilaProxy: Coleccionable, IObservador, Ordenable
	{
		
		Pila pilaReal = null;
		Comparable compMinimo = null;
		Comparable compMaximo = null;
		
		
		public PilaProxy(){}


		public int cuantos()
		{
			if (pilaReal != null)
				return pilaReal.cuantos();
			
			return 0;
		}

		public Comparable minimo()
		{
			if (pilaReal != null && compMinimo != null){
				compMinimo = pilaReal.minimo();
				return compMinimo;
			}
			if (compMinimo != null){
				return compMinimo;
			}
			return null;
		}

		public Comparable maximo()
		{
			if (pilaReal != null && compMaximo != null){
				compMaximo = pilaReal.maximo();
				return compMaximo;
			}
			if (compMaximo != null){
				return compMaximo;
			}
			return null;
		}

		public void agregar(Comparable comp)
		{	
			obtenerPilaReal().agregar(comp);
			pilaReal.notificar();
		}

		public bool contiene(Comparable comp)
		{
			if (pilaReal != null)
				return pilaReal.contiene(comp);
			
			return false;
		}

		//implementacion de IObservador

		public void actualizar(IObservado o)
		{
			compMinimo = pilaReal.minimo();
			compMaximo = pilaReal.maximo();
		}
		
		//implementation de Ordenable
		public void setOrdenInicio(OrdenEnAula1 orden)
		{
			((Pila)obtenerPilaReal()).setOrdenInicio(orden);
		}
		public void setOrdenLlegaAlumno(OrdenEnAula2 orden)
		{
			((Pila)obtenerPilaReal()).setOrdenLlegaAlumno(orden);
		}
		public void setOrdenAulaLlena(OrdenEnAula1 orden)
		{
			((Pila)obtenerPilaReal()).setOrdenAulaLlena(orden);
		}
		
		
		//Metodo auxiliar
		public Coleccionable obtenerPilaReal(){
			if(pilaReal == null)
				pilaReal = new Pila();
			return pilaReal;
		}
	}
}
