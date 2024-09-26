
using System;
using System.Linq;

namespace Practica01
{
	class Program
	{
		public static void Main(string[] args)
		{
			
			Pila pila = new Pila();
			Cola cola = new Cola();
			ColeccionMultiple multiple = new ColeccionMultiple(pila, cola);
			llenarAlumnos(pila);
			llenarAlumnos(cola);
			
			informar(pila);
			informar(cola);
			

			
			
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
				Persona personaRandom = new Persona("Persona" + i, random.Next(0, 100));
				coll.agregar(personaRandom);
			}
		}
		
		public static void llenarAlumnos(Coleccionable coll) {
			Random random = new Random();
			
			for (int i = 0; i < 20; i++)
			{
				Alumno alumnoRandom = new Alumno("Persona" + i, random.Next(0, 100),
				                                 random.Next(0, 1000), random.Next(0, 10));
				coll.agregar(alumnoRandom);
			}
		}
		
		public static void informar(Coleccionable coll)
		{
		
			Console.WriteLine("Ingrese el número de opción del tipo de Comparable a consultar:");
			Console.WriteLine("1. Numero \n2. Persona \n3. Alumno \n0. Salir");

			bool opValida = false;
			int[] rangoOpciones = { 0, 1, 2, 3 };
			int opcion = -1;

			while (!opValida)
			{
				try
				{
					opcion = int.Parse(Console.ReadLine());

					if (opcion == 0)
					{
						Console.WriteLine("Operación cancelada.\n");
						return;  // Se sale del método, cancelando todo lo siguiente.
					}

					if (rangoOpciones.Contains(opcion))
					{
						opValida = true;
					}
					else
					{
						Console.WriteLine("Ingrese un número de opción válida...\n");
					}
				}
				catch (FormatException)
				{
					Console.WriteLine("Error. Ingrese un número válido...\n");
				}
			}

			Comparable objBuscado = null;

			switch (opcion)
			{
				case 1:
					bool numValido = false;
					while (!numValido)
					{
						try
						{
							Console.WriteLine("Ingrese el número a consultar en la colección: ");
							Numero numBusq = new Numero(int.Parse(Console.ReadLine()));
							objBuscado = numBusq;
							numValido = true;
						}
						catch (FormatException)
						{
							Console.WriteLine("Error. Ingrese un número entero válido...\n");
						}
					}
					break;

				case 2:
					bool dniValido = false;
					while (!dniValido)
					{
						try
						{
							Console.WriteLine("Ingrese el número de DNI de la persona a consultar en la colección: ");
							Persona perBusq = new Persona("Persona", int.Parse(Console.ReadLine()));
							objBuscado = perBusq;
							dniValido = true;
						}
						catch (FormatException)
						{
							Console.WriteLine("Error. El DNI debe ser un número entero...\n");
						}
					}
					break;

				case 3:
					bool legajoValido = false;
					while (!legajoValido)
					{
						try
						{
							Console.WriteLine("\nIngrese el número de Legajo del alumno a consultar en la colección: ");
							Alumno alumBusq = new Alumno("Alumno", 0, int.Parse(Console.ReadLine()), 0);
							objBuscado = alumBusq;
							legajoValido = true;
						}
						catch (FormatException)
						{
							Console.WriteLine("\nError. El Legajo debe ser un número entero...\n");
						}
					}
					break;
			}

			Console.WriteLine("\nCantidad: {0} \nMinimo: \n{1} \nMaximo: \n{2} \nContiene valor consultado: {3}\n",
			                  coll.cuantos(), coll.minimo(), coll.maximo(), coll.contiene(objBuscado));
		}

	}
}