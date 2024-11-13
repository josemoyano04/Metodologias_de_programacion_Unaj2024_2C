
using System;

namespace Practica07
{
	public class FabricaDePila: FabricaDeColeccionables
	{
		public FabricaDePila(){}
		
		//Implementacion de FabricaDeColeccionables
		public override Coleccionable crearColeccion()
		{
			return new Pila();
		}
	}
}
