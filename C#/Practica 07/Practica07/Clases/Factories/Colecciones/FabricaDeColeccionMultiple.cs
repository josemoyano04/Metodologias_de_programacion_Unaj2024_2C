﻿
using System;

namespace Practica07
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
