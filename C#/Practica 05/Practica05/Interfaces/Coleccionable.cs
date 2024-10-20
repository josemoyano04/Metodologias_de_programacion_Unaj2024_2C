
using System;

namespace Practica05
{
	public interface Coleccionable
	{
		int cuantos();
		Comparable minimo();
		Comparable maximo();
		void agregar(Comparable comp);
		bool contiene(Comparable comp);
	}
}
