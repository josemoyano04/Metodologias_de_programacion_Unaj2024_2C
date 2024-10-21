
using System;

namespace Practica05
{
	public class ColaProxy: Coleccionable, IObservador, Ordenable
	{
		Cola colaReal = null;
		Comparable compMinimo = null;
		Comparable compMaximo = null;
		
		
		public ColaProxy(){}


		public int cuantos()
		{
			if (colaReal != null)
				return colaReal.cuantos();
			
			return 0;
		}

		public Comparable minimo()
		{
			if (colaReal != null && compMinimo != null){
				compMinimo = colaReal.minimo();
				return compMinimo;
			}
			if (compMinimo != null){
				return compMinimo;
			}
			return null;
		}

		public Comparable maximo()
		{
			if (colaReal != null && compMaximo != null){
				compMaximo = colaReal.minimo();
				return compMaximo;
			}
			if (compMaximo != null){
				return compMaximo;
			}
			return null;
		}

		public void agregar(Comparable comp)
		{
			if(colaReal == null)
				colaReal = new Cola();
			
			colaReal.agregar(comp);
			colaReal.notificar();
		}

		public bool contiene(Comparable comp)
		{
			if (colaReal != null)
				return colaReal.contiene(comp);
			
			return false;
		}

		//implementacion de IObservador 

		public void actualizar(IObservado o)
		{
			compMinimo = colaReal.minimo();
			compMaximo = colaReal.maximo();
		}
		
		//implementation de Ordenable
		public void setOrdenInicio(OrdenEnAula1 orden)
		{
			((Cola)obtenerColaReal()).setOrdenInicio(orden);
		}
		public void setOrdenLlegaAlumno(OrdenEnAula2 orden)
		{
			((Cola)obtenerColaReal()).setOrdenLlegaAlumno(orden);
		}
		public void setOrdenAulaLlena(OrdenEnAula1 orden)
		{
			((Cola)obtenerColaReal()).setOrdenAulaLlena(orden);
		}
		
		
		//Metodo auxiliar
		public Coleccionable obtenerColaReal(){
			if(colaReal == null)
				colaReal = new Cola();
			return colaReal;
		}
	}
}
