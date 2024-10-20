
using System;

namespace Practica05
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
