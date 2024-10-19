
using System;

namespace Practica04
{
	public abstract class FabricaDeComparables
	{
		protected GeneradorDeDatosAleatorios aleatorio = new GeneradorDeDatosAleatorios();
		protected LectorDeDatos teclado = new LectorDeDatos();
		
		
		//Metodos abstractos a implementar en subclases
		public abstract Comparable crearAleatorio();
		public abstract Comparable crearPorTeclado();
		
		
		//Metodos de clase
		//Funciones
		/// <summary>
		/// Crea una instancia de una subclase de Comparable con valores aleatorios.
		/// </summary>
		/// <param name="opcion">
		/// Tipos de instancia a crear:
		/// 0 = new Numero() | 1 = new Profesor() | 2 = new Alumno() | 
		/// 3 = new AlumnoFavorito() | 4 = new FabricaDeAlumnosMuyEstudiosos()
		/// </param>
		public static Comparable crearAleatorio(int opcion){
			FabricaDeComparables fabrica = null;
			switch (opcion) {
				case 0: //Fabrica de números
					fabrica = new FabricaDeNumeros();
					break;
				case 1: //Fabrica de profesor
					fabrica = new FabricaDeProfesor();
					break;
				case 2: //Fabrica de alumnos
					fabrica = new FabricaDeAlumnos();
					break;
				case 3: //Fabrica de alumnos favoritos
					fabrica = new FabricaDeAlumnosFavoritos();
					break;
				case 4: //Fabrica de alumnos muy estudiosos
					fabrica = new FabricaDeAlumnosMuyEstudiosos();
					break;
			}
			
			return fabrica.crearAleatorio();
		}
		
		/// <summary>
		/// Crea una instancia de una subclase de Comparable con valores ingresador por teclado.
		/// </summary>
		/// <param name="opcion">
		/// Tipos de instancia a crear:
		/// 0 = New Numero() | 1 = New Profesor() | 2 = New Alumno()
		/// </param>
		public static Comparable crearPorTeclado(int opcion){
			FabricaDeComparables fabrica = null;
			switch (opcion) {
				case 0: //Fabrica de números
					fabrica = new FabricaDeNumeros();
					break;
				case 1: //Fabrica de alumnos
					fabrica = new FabricaDeAlumnos();
					break;
			}
			
			return fabrica.crearPorTeclado();
		}
	}
}
