using System;

namespace Practica04
{

	public interface IObservado
	{	
		void agregarObservador(IObservador observador);
		void eliminarObservador(IObservador observador);
		void notificar();
	}
}
