using System;

namespace Practica03
{

	public interface IObservado
	{	
		void agregarObservador(IObservador observador);
		void eliminarObservador(IObservador observador);
		void notificar();
	}
}
