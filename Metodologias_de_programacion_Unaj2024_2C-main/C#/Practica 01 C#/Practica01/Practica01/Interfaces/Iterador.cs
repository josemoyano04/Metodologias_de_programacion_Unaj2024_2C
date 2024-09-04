using System;

namespace Practica01
{
	public interface Iterador
	{
		void primero();
		void siguiente();
		bool fin();
		Comparable actual();
	}
}
