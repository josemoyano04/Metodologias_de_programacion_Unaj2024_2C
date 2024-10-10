
using System;

namespace Practica03
{
	public abstract class FabricaDeComparables
	{
		protected GeneradorDeDatosAleatorios aleatorio = new GeneradorDeDatosAleatorios();
		protected LectorDeDatos teclado = new LectorDeDatos();
		
		
		//Metodos abstractos a implementar en subclases
		public abstract Comparable crearAleatorio();
		public abstract Comparable crearPorTeclado();
		
		
		//Metodos de clase
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
			}
			
			return fabrica.crearAleatorio();
		}
		
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
