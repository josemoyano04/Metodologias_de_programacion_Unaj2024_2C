
using System;

namespace Practica03
{
	/// <summary>
	/// Description of FabricaDeProfesor.
	/// </summary>
	public class FabricaDeProfesor: FabricaDeComparables
	{
		public FabricaDeProfesor(){}
		
		public override Comparable crearAleatorio()
		{
			string nombreAl = aleatorio.stringAleatorio(10);
			int dniAl = aleatorio.numeroAleatorio(1000000);
			int antiguedadAl= aleatorio.numeroAleatorio(25);
			
			return new Profesor(nombreAl, dniAl, antiguedadAl);
		}
		
		public override Comparable crearPorTeclado()
		{
			Console.Write("Nombre: ");
			string nombreTec = teclado.stringPorTeclado();
			Console.Write("Dni: ");
			int dniTec = teclado.numerosPorTeclado();
			Console.Write("Antigueda: ");
			int antiguedadTec = teclado.numerosPorTeclado();
			
			return new Profesor(nombreTec, dniTec, antiguedadTec);
		}
	}
}
