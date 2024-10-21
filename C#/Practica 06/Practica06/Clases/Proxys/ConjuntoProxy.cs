
using System;

namespace Practica06
{
	public class ConjuntoProxy: Coleccionable, IObservador, Ordenable
	{
		Conjunto conjuntoReal = null;
		Comparable compMinimo = null;
		Comparable compMaximo = null;
		
		
		public ConjuntoProxy(){}


		public int cuantos()
		{
			if (conjuntoReal != null)
				return conjuntoReal.cuantos();
			
			return 0;
		}

		public Comparable minimo()
		{
			if (conjuntoReal != null && compMinimo != null){
				compMinimo = conjuntoReal.minimo();
				return compMinimo;
			}
			if (compMinimo != null){
				return compMinimo;
			}
			return null;
		}

		public Comparable maximo()
		{
			if (conjuntoReal != null && compMaximo != null){
				compMaximo = conjuntoReal.maximo();
				return compMaximo;
			}
			if (compMaximo != null){
				return compMaximo;
			}
			return null;
		}

		public void agregar(Comparable comp)
		{
			if(conjuntoReal == null)
				conjuntoReal = new Conjunto();
			
			conjuntoReal.agregar(comp);
			conjuntoReal.notificar();
		}

		public bool contiene(Comparable comp)
		{
			if (conjuntoReal != null)
				return conjuntoReal.contiene(comp);
			
			return false;
		}

		//implementacion de IObservador 

		public void actualizar(IObservado o)
		{
			compMinimo = conjuntoReal.minimo();
			compMaximo = conjuntoReal.maximo();
		}
		
		//implementation de Ordenable
		public void setOrdenInicio(OrdenEnAula1 orden)
		{
			((Conjunto)obtenerConjuntoReal()).setOrdenInicio(orden);
		}
		public void setOrdenLlegaAlumno(OrdenEnAula2 orden)
		{
			((Conjunto)obtenerConjuntoReal()).setOrdenLlegaAlumno(orden);
		}
		public void setOrdenAulaLlena(OrdenEnAula1 orden)
		{
			((Conjunto)obtenerConjuntoReal()).setOrdenAulaLlena(orden);
		}
		
		
		//Metodo auxiliar
		public Coleccionable obtenerConjuntoReal(){
			if(conjuntoReal == null)
				conjuntoReal = new Conjunto();
			return conjuntoReal;
		}
	}
}
