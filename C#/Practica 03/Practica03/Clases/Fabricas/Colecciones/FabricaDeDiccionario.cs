
using System;

namespace Practica03
{
	public class FabricaDeDiccionario: FabricaDeColeccionables
	{
		public FabricaDeDiccionario(){}
		
		//Implementacion de FabricaDeColeccionables
		public override Coleccionable crearColeccion()
		{
			return new Diccionario();
		}
	}
}
