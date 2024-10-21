
using System;

namespace Practica06
{

	public class OrdenInicio: OrdenEnAula1
	{
		private Aula aula;
		public OrdenInicio(Aula aula)
		{
			this.aula = aula;
		}

		public void ejecutar()
		{
			aula.comenzar();
		}
	}
}
