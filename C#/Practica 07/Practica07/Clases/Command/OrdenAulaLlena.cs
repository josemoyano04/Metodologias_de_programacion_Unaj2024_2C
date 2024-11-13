
using System;

namespace Practica07
{

	public class OrdenAulaLlena: OrdenEnAula1
	{
		Aula aula;
		public OrdenAulaLlena(Aula aula)
		{
			this.aula = aula;
		}
		
		public void ejecutar(){
			aula.claseLista();
		}
	}
}
