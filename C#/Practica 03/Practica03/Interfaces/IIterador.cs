using System;

namespace Practica03
{
	public interface IIterador
	{
		void primero();
		void siguiente();
		bool fin();
		Comparable actual();
	}
}
