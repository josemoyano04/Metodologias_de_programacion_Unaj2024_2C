using System;

namespace Practica06
{
	public interface IIterador
	{
		void primero();
		void siguiente();
		bool fin();
		Comparable actual();
	}
}
