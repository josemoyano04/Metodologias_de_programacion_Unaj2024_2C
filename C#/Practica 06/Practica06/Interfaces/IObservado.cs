using System;

namespace Practica06
{

	public interface IObservado
	{	
		void agregarObservador(IObservador observador);
		void eliminarObservador(IObservador observador);
		void notificar();
	}
}
