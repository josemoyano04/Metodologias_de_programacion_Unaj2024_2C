
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
			
			Teacher teacher = new Teacher();
			
			//Agregado de 20 Students Decorados 
			for (int i = 0; i < 10; i++) {
				
				//Creacion de AlumnoAdapter Decorado
				AlumnoAdapter alumnoBase = StudentsFactory.crearAleatorio(0); 
				
				//Creacion de AlumnoAdapter Muy Estudioso Decorado
				AlumnoAdapter alumnoMuyEstudioso = StudentsFactory.crearAleatorio(1);
				
				teacher.goToClass(alumnoBase);
				teacher.goToClass(alumnoMuyEstudioso);
			}
			
			teacher.teachingAClass();

			Console.Write("Ok 200");
			Console.ReadKey(true);
		}



		//Funciones
		
		/// <summary>
		/// Agrega 20 instancias de Comparables especificador por parametro a una instancia de Coleccionable
		/// </summary>
		/// <param name="coll">Instancia de Coleccionable</param>
		/// <param name="opcion">
		/// Tipos de instancia a agregar:
		/// 0 = New Numero() | 1 = New Profesor() | 2 = New Alumno()
		/// </param>
		public static void llenar(Coleccionable coll, int opcion)
		{

			for (int i = 0; i < 20; i++)
			{
				Comparable c = FabricaDeComparables.crearAleatorio(opcion);
				coll.agregar(c);
				//Espera de 1 milisegundo a fin de que la instancia de Random no repita los mismos valores
				Thread.Sleep(1);
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

		//Ejercicio 13
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

		public static void mainPractica03()
		{
			//*******************************************************************************
			//Ejercicio 7 opcional →Seleccion de tipo de coleccion

			//Instanciacion de lector de datos
			LectorDeDatos teclado = new LectorDeDatos();

			//Menu de tipos de colecciones
			Console.WriteLine("---SELECCION DE COLECCIÓN DE DATOS---");
			Console.WriteLine();
			Console.WriteLine("→Ingrese un numero de opción correspondiente a la coleccion donde desea guardar los datos");
			Console.WriteLine("1. Pila \n2. Cola\n3. Conjunto\n4. Diccionario\n5. Coleccion Multiple");

			//Al utilizar el lector, evito el manejo de errores por ingresar caracteres
			//no numericos, ya que dicho control se realiza internamente en el Lector:
			int[] OP_VALIDAS = { 1, 2, 3, 4, 5 };
			int opColeccion = -1;
			while (!OP_VALIDAS.Contains(opColeccion))
			{
				Console.Write("Opcion: ");
				opColeccion = teclado.numerosPorTeclado();
				if (!OP_VALIDAS.Contains(opColeccion))
					Console.WriteLine("Ingrese una opción valida");
			}

			//Creacion de coleccion seleccionada por usuario
			Coleccionable coleccion = FabricaDeColeccionables.crearColeccion(opColeccion);

			//*******************************************************************************

			//Ejercicio 14 y 15(Opcional)
			Profesor profesor = (Profesor)FabricaDeComparables.crearAleatorio(1);
			AlumnoFavorito alumnoFav = (AlumnoFavorito)FabricaDeComparables.crearAleatorio(3);

			alumnoFav.agregarObservador(profesor); //Profesor se vuelve observador del Alumno Favorito
			profesor.agregarObservador(alumnoFav); //Alumno Favorito se vuelve observador de Profesor como todos sus compañeros

			//Utilizacion de coleccion elegida por el usuario para almacenar 20 alumnos
			llenar(coleccion, 2);


			// Iteracion de coleccion para agregar cada alumno de la coleccion como observador de profesor,
			// el alumnoFav como observador de cada alumno, el profesor como observador de alumnoFav,
			// y control de errores generados al iterar colecciones complejas como Diccionarios o Colecciones Multiples

			try
			{

				IIterador iterador = ((IIterable)coleccion).crearIterador();
				while (!iterador.fin())
				{
					//Profesor observado por alumno
					profesor.agregarObservador((IObservador)iterador.actual());

					//Alumno observado por AlumnoFavorito
					((IObservado)iterador.actual()).agregarObservador(alumnoFav);

					iterador.siguiente();
				}

				//A fin de tener la coleccion completa de los alumnos de la clase, se agrega el Alumno Favorito a la coleccion
				coleccion.agregar(alumnoFav);


				dictadoDeClases(profesor);

			}
			catch (InvalidCastException e)
			{
				// Control de errores producidos al utilizar colecciones complejas para guardar alumnos.
				// Funcionalidad no implementada por falta de solicitud de la misma.

				Console.WriteLine();
				Console.WriteLine("Seleccione tipo de coleccion Pila, Cola o Conjunto para evitar errores.");
				Console.WriteLine("Error: " + e);
			}


			//Dictado de clase

			Console.ReadKey(true);
		}
	}
}