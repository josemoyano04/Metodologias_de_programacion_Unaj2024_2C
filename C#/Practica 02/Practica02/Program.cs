
using System;
using System.Collections.Generic;
using System.Linq;

namespace Practica02
{
	class Program
	{
		public static void Main(string[] args)
		{	
			//Ejercicio 14(opcional)
			multiplesIteradores();
			
			// Creación de las estructuras
			Pila pila = new Pila();
			Cola cola = new Cola();
			Conjunto conjunto = new Conjunto();
			Diccionario diccionario = new Diccionario();
			
			// Llenar las estructuras con alumnos
			llenarAlumnos(cola);
			llenarAlumnos(conjunto);
			llenarAlumnos(diccionario);
			
			//Ejercicio 13(opcional)
			imprimirAlumPromedioMayor7(conjunto);
			
			llenarAlumnos(pila);
			cambiarEstrategia(pila, new CompAlumnPorNombre());
			informar(pila);
			cambiarEstrategia(pila, new CompAlumnPorLegajo());
			informar(pila);
			cambiarEstrategia(pila, new CompAlumnPorDni());
			informar(pila);
			cambiarEstrategia(pila, new CompAlumnPorPromedio());
			informar(pila);
			
			
			// Imprimir los elementos de cada estructura
			Console.WriteLine("************************************************************");
			Console.WriteLine("*                          Pila                             *");
			Console.WriteLine("************************************************************");
			imprimirElementos(pila);

			Console.WriteLine("************************************************************");
			Console.WriteLine("*                          Cola                             *");
			Console.WriteLine("************************************************************");
			imprimirElementos(cola);

			Console.WriteLine("************************************************************");
			Console.WriteLine("*                        Conjunto                           *");
			Console.WriteLine("************************************************************");
			imprimirElementos(conjunto);

			Console.WriteLine("************************************************************");
			Console.WriteLine("*                       Diccionario                         *");
			Console.WriteLine("************************************************************");
			imprimirElementos(diccionario);
			
			Console.ReadKey(true);
		}
		
		//Funciones
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
				Alumno alumnoRandom = new Alumno("Alumno" + i, i,
				                                 i + 20, random.Next(0, 10));
				coll.agregar(alumnoRandom);
			}
		}
		
		public static void llenarAlumnos(Diccionario dict)//Implementacion llenar diccionarios
		{
			Random random = new Random();
			
			for (int i = 0; i < 20; i++)
			{
				Alumno alumnoRandom = new Alumno("Alumno" + i, i,
				                                 i + 20, random.Next(0, 10));
				dict.agregar(new Numero(i + 100), alumnoRandom);
			}
		}
		
		public static void informar(Coleccionable coll)
		{
			//Solicitud de tipo de Comparable a a consultar
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
			
			//Solicitud de dato del Comparable buscado
			Comparable objBuscado = null;

			switch (opcion)
			{
				case 1: //Instancia de Numero -> Comparacion por valor
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

				case 2: //Instancia de Persona -> Comparación por DNI
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

				case 3: // Instancia de Alumno -> Comparación definida por patrón Strategy

					Alumno alumnoBuscado = new Alumno("Alumno-1", -1, -1, -1);
					bool estrategiaValida = false;

					while (!estrategiaValida)
					{
						Console.WriteLine("Seleccione el tipo de dato para buscar al Alumno:");
						Console.WriteLine("1. Por Nombre \n2. Por DNI \n3. Por Legajo \n4. Por Promedio");

						int estrategia;
						try
						{
							estrategia = int.Parse(Console.ReadLine());

							switch (estrategia)
							{
								case 1:
									alumnoBuscado.SetEstrategia(new CompAlumnPorNombre());
									Console.WriteLine("Ingrese el nombre: ");
									alumnoBuscado.setNombre(Console.ReadLine());
									estrategiaValida = true;
									break;

								case 2:
									alumnoBuscado.SetEstrategia(new CompAlumnPorDni());
									Console.WriteLine("Ingrese el DNI: ");
									alumnoBuscado.setDni(int.Parse(Console.ReadLine()));
									estrategiaValida = true;
									break;

								case 3:
									alumnoBuscado.SetEstrategia(new CompAlumnPorLegajo());
									Console.WriteLine("Ingrese el legajo: ");
									alumnoBuscado.setLegajo(int.Parse(Console.ReadLine()));
									estrategiaValida = true;
									break;

								case 4:
									alumnoBuscado.SetEstrategia(new CompAlumnPorPromedio());
									Console.WriteLine("Ingrese el promedio: ");
									alumnoBuscado.setPromedio(double.Parse(Console.ReadLine()));
									estrategiaValida = true;
									break;

								default:
									Console.WriteLine("Opción inválida. Intente nuevamente.");
									break;
							}
						}
						catch (FormatException)
						{
							Console.WriteLine("Error. Por favor, ingrese un número válido.");
						}
					}

					objBuscado = alumnoBuscado;
					break;

			}

			Console.WriteLine("\nCantidad: {0} \nMinimo: \n{1} \nMaximo: \n{2} \nContiene valor consultado: {3}\n",
			                  coll.cuantos(), coll.minimo(), coll.maximo(), coll.contiene(objBuscado));
		}
		
		public static void imprimirElementos(Coleccionable coll){

			IIterador iterador = ((IIterable)coll).crearIterador();
			
			while (!iterador.fin()) {
				Console.WriteLine(iterador.actual());
				iterador.siguiente();
			}
			
		}
		
		public static void cambiarEstrategia(Coleccionable coll, IEstrategiaCompAlumno estr){
			IIterador iterador = ((IIterable)coll).crearIterador();
			
			
			while (!iterador.fin()) {
				try {
					((Alumno)iterador.actual()).SetEstrategia(estr);
					
					iterador.siguiente();
				} catch (InvalidCastException) {
					continue;
				}
			}
			
		}
	
		//Ejercicio 13(Opcional) -> iterador de conjunto
		public static void imprimirAlumPromedioMayor7(Conjunto conjAlumnos){
			
			Alumno alumnoPromedio = new Alumno(null, -1, -1, 7.0);
			
			cambiarEstrategia(conjAlumnos, new CompAlumnPorPromedio());
			Pila alumPromMayor7 = new Pila();
			
			IteradorConjunto iterador = (IteradorConjunto)conjAlumnos.crearIterador();
			
			while (!iterador.fin()) {
				if(iterador.actual().sosIgual(alumnoPromedio) || 
				   iterador.actual().sosMayor(alumnoPromedio))
					alumPromMayor7.agregar(iterador.actual());
				iterador.siguiente();
			}
			Console.WriteLine("************************************************************");
			Console.WriteLine("*             Alumnos con promedio mayor a 7               *");
			Console.WriteLine("************************************************************");
			
			imprimirElementos(alumPromMayor7);
		}
	
		//Ejercicio 14(Opcional)
		public static void multiplesIteradores(){
//			Diccionario coleccion = new Diccionario(); //Prueba con diccionario
			Pila coleccion = new Pila(); //Prueba con Pila
			llenarAlumnos(coleccion);
			
			//Creacion de Iteradores:
			IIterador [] iteradores = new IIterador[3];
			
			for (int i = 0; i < 3; i++) {
				iteradores[i] = coleccion.crearIterador();
			}
			
			
			Random random = new Random();
			while (!iteradores[0].fin() && !iteradores[1].fin() && !iteradores[2].fin()) {
				int iteradorSelec = random.Next(0, 3);
				
				if(!iteradores[iteradorSelec].fin()){
					Console.WriteLine("Iterador: {0}", iteradorSelec );
					Console.WriteLine(iteradores[iteradorSelec].actual());
					iteradores[iteradorSelec].siguiente();
				}
			}
			
		}
	}
}