
using System;

namespace Practica01
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
