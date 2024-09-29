using System;

namespace Practica02
{
	public interface IIterador
	{
		void primero();
		void siguiente();
		bool fin();
		Comparable actual();
	}
}
