using System;

namespace Practica05
{

	public interface IObservado
	{	
		void agregarObservador(IObservador observador);
		void eliminarObservador(IObservador observador);
		void notificar();
	}
}
