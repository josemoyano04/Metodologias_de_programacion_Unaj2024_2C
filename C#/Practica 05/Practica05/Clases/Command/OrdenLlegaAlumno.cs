
using System;

namespace Practica05
{
	public class OrdenLlegaAlumno: OrdenEnAula2
	{
		Aula aula;
		
		public OrdenLlegaAlumno(Aula aula)
		{
			this.aula = aula;
		}
		
		public void ejecutar(Comparable comparable)
		{
			try {
				aula.nuevoAlumno((AlumnoAdapter)comparable);
			} catch (InvalidCastException eror) {
				Console.WriteLine("Error:" + eror);
			}
		}
	}
}
