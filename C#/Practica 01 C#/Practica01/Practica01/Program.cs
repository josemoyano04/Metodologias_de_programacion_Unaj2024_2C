
using System;

namespace Practica01
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Pila pila = new Pila();
			Cola cola = new Cola();
			ColeccionMultiple multiple = new ColeccionMultiple(pila, cola);
			llenarPersonas(pila);
			llenarPersonas(cola);
			informar(multiple);

			
			
			Console.ReadKey(true);
		}
		public static void llenar(Coleccionable coll)
		{
			Random random = new Random();
			
			for (int i = 0; i < 20; i++)
			{
				int numRandom = random.Next(0, 100);
				coll.agregar(new Numero(numRandom));
			}
			
		}
		
		public static void llenarPersonas(Coleccionable coll) {
			Random random = new Random();
			
			for (int i = 0; i < 20; i++)
			{
				int numRandom = random.Next(0, 100);
				Persona personaRandom = new Persona("Persona" + i, numRandom);
				coll.agregar(personaRandom);
			}
		}
		
		public static void informar(Coleccionable coll)
		{
			Console.WriteLine("Ingrese un número a consultar en la coleccion: ");
			
			Numero valor_consultado  = null;
			bool valido = false;
			while (!valido) {
				try {
					valor_consultado = new Numero(int.Parse(Console.ReadLine()));
					valido = true;
				} catch (Exception) {
					Console.WriteLine("Ingrese un número");
				}
			}
			
			
			Console.WriteLine("Cantidad: {0} \nMinimo: {1} \nMaximo: {2}, Contiene {3}: {4}\n",
			                  coll.cuantos(), coll.minimo(), coll.maximo(), valor_consultado.getValor(),
			                  coll.contiene(valor_consultado));
		}
		
	}
}