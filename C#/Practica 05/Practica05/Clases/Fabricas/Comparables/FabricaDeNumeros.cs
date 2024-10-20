
using System;

namespace Practica05
{
	public class FabricaDeNumeros : FabricaDeComparables
	{	
		
		public override Comparable crearAleatorio()
		{
			int n = aleatorio.numeroAleatorio(1000);
			return new Numero(n);
		}
		
		public override Comparable crearPorTeclado()
		{
			Console.WriteLine("---CREAR NUMERO---");
			Console.Write("valor: ");
			int n = teclado.numerosPorTeclado();
			return new Numero(n);
		}
	}
}
