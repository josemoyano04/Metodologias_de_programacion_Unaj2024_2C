
using System;
using ObtencionDeDatos;

namespace Practica07
{
	public abstract class FabricaDeComparables
	{
		protected GeneradorDeDatosAleatorios aleatorio = GeneradorDeDatosAleatorios.GetInstance();
		protected LectorDeDatos teclado = LectorDeDatos.GetInstance();
		protected LectorDeArchivos lectorArchivos = new LectorDeArchivos();
		
		//Valores constantes de opciones:
		private const int NUMERO = 0;
		private const int PROFESOR = 1;
		private const int ALUMNO = 2;
		private const int ALUMNO_FAVORITO = 3;
		private const int ALUMNO_MUY_ESTUDIOSO = 4;
		private const int ALUMNO_PROXY = 5;
		private const int ALUMNO_MUY_ESTUDIOSO_PROXY = 6;
		private const int ALUMNO_COMPUESTO_BASICO = 7;
		private const int ALUMNO_COMPUESTO_MUY_ESTUDIOSO = 8;
		
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
		/// 0 = Numero| 1 = Profesor | 2 = Alumno |
		/// 3 = AlumnoFavorito | 4 = FabricaDeAlumnosMuyEstudiosos |
		/// 5 = AlumnoProxy | 6 = AlumnoMuyEstudiosoProxy |
		/// 7 = AlumnoCompuesto (x5 AlumnoProxy) | 
		/// 8 = AlumnoCompuesto (x5 AlumnoMuyEstudiosoProxy)
		/// </param>
		public static Comparable crearAleatorio(int opcion)
		{
			return obtenerFabrica(opcion).crearAleatorio();
		}

		/// <summary>
		/// Crea una instancia de una subclase de Comparable con valores ingresador por teclado.
		/// </summary>
		/// <param name="opcion">
		/// Tipos de instancia a crear:
		/// 0 = Numero| 1 = Profesor | 2 = Alumno |
		/// 3 = AlumnoFavorito | 4 = FabricaDeAlumnosMuyEstudiosos |
		/// 5 = AlumnoProxy | 6 = AlumnoMuyEstudiosoProxy |
		/// 7 = AlumnoCompuesto (x5 AlumnoProxy) | 
		/// 8 = AlumnoCompuesto (x5 AlumnoMuyEstudiosoProxy)
		/// </param>
		
		public static Comparable crearPorTeclado(int opcion)
		{
			return obtenerFabrica(opcion).crearPorTeclado();
		}
		
		public static FabricaDeComparables obtenerFabrica(int opcion){
			FabricaDeComparables fabrica = null;
			switch (opcion)
			{
				case NUMERO: //Fabrica de números
					fabrica = new FabricaDeNumeros();
					break;
				case PROFESOR: //Fabrica de profesor
					fabrica = new FabricaDeProfesor();
					break;
				case ALUMNO: //Fabrica de alumnos
					fabrica = new FabricaDeAlumnos();
					break;
				case ALUMNO_FAVORITO: //Fabrica de alumnos favoritos
					fabrica = new FabricaDeAlumnosFavoritos();
					break;
				case ALUMNO_MUY_ESTUDIOSO: //Fabrica de alumnos muy estudiosos
					fabrica = new FabricaDeAlumnosMuyEstudiosos();
					break;
				case ALUMNO_PROXY:
					fabrica = new FabricaDeAlumnoProxy();
					break;
				case ALUMNO_MUY_ESTUDIOSO_PROXY:
					fabrica = new FabricaDeAlumnoMuyEstudiosoProxy();
					break;
				case ALUMNO_COMPUESTO_BASICO:
					//Contiene como hijos 5 alumnos proxy
					fabrica = new FabricaDeAlumnoCompuesto(1);
					break;
				case ALUMNO_COMPUESTO_MUY_ESTUDIOSO:
					//Contiene como hijos 5 alumnos muy estudisos proxy
					fabrica = new FabricaDeAlumnoCompuesto(2);
					break;
			}

			return fabrica;
		}
	}
}
