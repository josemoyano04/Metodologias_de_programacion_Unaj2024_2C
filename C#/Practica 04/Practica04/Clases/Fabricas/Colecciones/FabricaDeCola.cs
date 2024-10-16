
using System;

namespace Practica04
{
	//Ejercicio 7 (opcional)
	public class FabricaDeCola: FabricaDeColeccionables
	{
		public FabricaDeCola(){}
		
		//Implementacion de FabricaDeColeccionables
		public override Coleccionable crearColeccion()
		{
			return new Cola();
		}
	}
}
