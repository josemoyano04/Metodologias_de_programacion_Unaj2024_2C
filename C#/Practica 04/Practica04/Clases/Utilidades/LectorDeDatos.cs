using System;

namespace Practica04
{
	public class LectorDeDatos
	{
		public int numerosPorTeclado(){
			int n = -1;
			
			bool valido = false;
			while (!valido) {
				try {
					n = int.Parse(Console.ReadLine());
					valido = true;
				} catch (FormatException) {
					Console.WriteLine("Error. Ingrese un número");
				}
			}
			
			return n;
		}
		
		public string stringPorTeclado(){
			string s = Console.ReadLine();
			return s;
		}
	}
}
