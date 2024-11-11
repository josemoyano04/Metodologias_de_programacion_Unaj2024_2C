using System;
using System.Collections.Generic;

namespace Practica06
{
	public class MazosCartas
	{
		public MazosCartas(){}
		
		public static List<string> x50cartasEspañolas(){
			
			List<string> palos = new List<string>{"oro", "espada", "basto", "copa"};
			List<string> cartas = new List<string>();
			
			foreach(string p in palos){
				for(int i = 1; i <= 12; i++)
					cartas.Add(String.Format("{0} de {1}", i, p));
			}
			cartas.Add("Comodin");
			cartas.Add("Comodin");
			
			return cartas;
		}
		
		public static List<string> x40CartasEspañolas(){
			
			List<string> palos = new List<string>{"oro", "espada", "basto", "copa"};
			List<string> cartas = new List<string>();
			
			foreach(string p in palos){
				for(int i = 1; i <= 12; i++)
					if(i != 8 && i != 9)
						cartas.Add(String.Format("{0} de {1}", i, p));
			}
			
			return cartas;
		}
	}
}
