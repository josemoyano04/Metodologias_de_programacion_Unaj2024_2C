
using System;

namespace Practica06
{
	public class FabricaDeColeccionMultiple: FabricaDeColeccionables
	{
		public FabricaDeColeccionMultiple(){}
		
		public override Coleccionable crearColeccion()
		{
			Pila p = new Pila();
			Cola c = new Cola();
			return new ColeccionMultiple(p, c);
		}
	}
}
