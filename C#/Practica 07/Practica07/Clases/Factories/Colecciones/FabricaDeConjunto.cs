
using System;

namespace Practica07
{
	public class FabricaDeConjunto: FabricaDeColeccionables
	{
		public FabricaDeConjunto(){}
		
		//Implementacion de FabricaDeColeccionables
		public override Coleccionable crearColeccion()
		{
			return new Conjunto();
		}
	}
}
