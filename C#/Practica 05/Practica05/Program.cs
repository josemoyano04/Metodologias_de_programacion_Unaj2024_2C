﻿
using System;
using System.Linq;
using System.Threading;
using MDPI;

namespace Practica05
{
	class Program
	{
		public static void Main(string[] args)
		{
			PilaProxy pila = new PilaProxy();
			Aula aula = new Aula();
			pila.setOrdenInicio(new OrdenInicio(aula));
			pila.setOrdenLlegaAlumno(new OrdenLlegaAlumno(aula));
			pila.setOrdenAulaLlena(new OrdenAulaLlena(aula));
			
			llenar(pila, 5);
			llenar(pila, 6);
			
			Console.ReadKey(true);
		}



		//Funciones
		
		/// <summary>
		/// Agrega 20 instancias de Comparables especificador por parametro a una instancia de Coleccionable
		/// </summary>
		/// <param name="coll">Instancia de Coleccionable</param>
		/// <param name="opcion">
		/// Tipos de instancia a agregar:
		/// 0 = New Numero() | 1 = New Profesor() | 2 = New Alumno() |
		/// 3 = New AlumnoFavorito() | 4 = New AlumnoMuyEstudioso() |
		/// 5 = New AlumnoAdapter(Alumno) | 6 = New AlumnoAdapter(AlumnoMuyEstudioso)
		/// </param>
		public static void llenar(Coleccionable coll, int opcion)
		{
			if(opcion >= 1 && opcion <= 4)
			{
				for (int i = 0; i < 20; i++)
				{
					Comparable c = FabricaDeComparables.crearAleatorio(opcion);
					coll.agregar(c);
					//Espera de 1 milisegundo a fin de que la instancia de Random no repita los mismos valores
					Thread.Sleep(1);
				}
				return; //Una vez agregados los elementos, ejecuta una parada de la funcion evitando comparaciones siguientes no necesarias
			}
			
			int opcionAdaptada = opcion - 5; //Altera la opcion original restando 4 a su valor para adaptarla
			// a las opciones admitidas por StudentFactory
			if(opcion >= 5 && opcion <= 6)
			{
				
				for (int i = 0; i < 20; i++)
				{
					Comparable c = (AlumnoAdapter)StudentsFactory.crearAleatorio(opcionAdaptada);
					Console.WriteLine("Agregado: {0}", ((AlumnoAdapter)c).getName()); //****************************************
					coll.agregar(c);
					//Espera de 1 milisegundo a fin de que la instancia de Random no repita los mismos valores
					Thread.Sleep(1);
				}
				Console.WriteLine(); //****************************************
			}
			
		}

		public static void informar(Coleccionable coll, int opcion)
		{
			Console.WriteLine("INGRESE LOS DATOS DEL OBJETO BUSCADO: ");
			Comparable objBuscado = FabricaDeComparables.crearPorTeclado(opcion);
			Console.WriteLine("\nCantidad: {0} \nMinimo: \n{1} \nMaximo: \n{2} \nContiene valor consultado: {3}\n",
			                  coll.cuantos(), coll.minimo(), coll.maximo(), coll.contiene(objBuscado));
		}

		public static void imprimirElementos(Coleccionable coll)
		{

			IIterador iterador = ((IIterable)coll).crearIterador();

			while (!iterador.fin())
			{
				Console.WriteLine(iterador.actual());
				iterador.siguiente();
			}

		}

		public static void cambiarEstrategia(Coleccionable coll, IEstrategiaCompAlumno estr)
		{
			IIterador iterador = ((IIterable)coll).crearIterador();


			while (!iterador.fin())
			{
				try
				{
					((Alumno)iterador.actual()).SetEstrategia(estr);

					iterador.siguiente();
				}
				catch (InvalidCastException)
				{
					continue;
				}
			}

		}

		public static void imprimirAlumPromedioMayor7(Conjunto conjAlumnos)
		{

			Alumno alumnoPromedio = new Alumno(null, -1, -1, 7.0);

			cambiarEstrategia(conjAlumnos, new CompAlumnPorPromedio());
			Pila alumPromMayor7 = new Pila();

			IteradorConjunto iterador = (IteradorConjunto)conjAlumnos.crearIterador();

			while (!iterador.fin())
			{
				if (iterador.actual().sosIgual(alumnoPromedio) ||
				    iterador.actual().sosMayor(alumnoPromedio))
					alumPromMayor7.agregar(iterador.actual());
				iterador.siguiente();
			}
			Console.WriteLine("************************************************************");
			Console.WriteLine("*             Alumnos con promedio mayor a 7               *");
			Console.WriteLine("************************************************************");

			imprimirElementos(alumPromMayor7);
		}

		public static void multiplesIteradores()
		{
			//			Diccionario coleccion = new Diccionario(); //Prueba con diccionario
			Pila coleccion = new Pila(); //Prueba con Pila
			llenar(coleccion, 1);

			//Creacion de Iteradores:
			IIterador[] iteradores = new IIterador[3];

			for (int i = 0; i < 3; i++)
			{
				iteradores[i] = coleccion.crearIterador();
			}


			Random random = new Random();
			while (!iteradores[0].fin() && !iteradores[1].fin() && !iteradores[2].fin())
			{
				int iteradorSelec = random.Next(0, 3);

				if (!iteradores[iteradorSelec].fin())
				{
					Console.WriteLine("Iterador: {0}", iteradorSelec);
					Console.WriteLine(iteradores[iteradorSelec].actual());
					iteradores[iteradorSelec].siguiente();
				}
			}

		}

		public static void dictadoDeClases(Profesor p)
		{
			for (int i = 0; i < 5; i++)
			{

				Console.WriteLine("******************************************");
				p.hablarALaClase();
				Console.WriteLine();
				p.escribirEnElPizarron();
				Console.WriteLine("******************************************");

			}
		}
	}
}