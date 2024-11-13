using System;

namespace Practica07
{

	public interface IObservado
	{	
		void agregarObservador(IObservador observador);
		void eliminarObservador(IObservador observador);
		void notificar();
	}
}
