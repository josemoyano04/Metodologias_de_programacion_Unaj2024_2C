
using System;

namespace Practica03
{
	//Ejercicio 7(opciona)
	public abstract class FabricaDeColeccionables
	{
		//Metodo abstracto a implementar en creadores concretos
		public abstract Coleccionable crearColeccion();
		
		//Metodo de clase
		public static Coleccionable crearColeccion(int opcion){
			FabricaDeColeccionables fabrica = null;
			switch (opcion) {
				case 1: //Fabrica de pila
					fabrica = new FabricaDePila();
					break;
				case 2: //Fabrica de cola
					fabrica = new FabricaDeCola();
					break;
				case 3: //Fabrica de conjunto
					fabrica = new FabricaDeConjunto();
					break;
				case 4: //Fabrica de diccionario
					fabrica = new FabricaDeDiccionario();
					break;
				case 5: //Fabrica de coleccion multiple
					fabrica = new FabricaDeColeccionMultiple();
					break;
			}
			
			return fabrica.crearColeccion();
		}
	}
}
