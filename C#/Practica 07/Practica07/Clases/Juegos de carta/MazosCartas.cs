using System;
using System.Collections.Generic;

namespace Practica07
{
	public class MazosCartas
	{
		private MazosCartas(){}

        public static List<Carta> X50CartasEspañolas()
        {

            List<string> palos = new List<string> { "oro", "espada", "basto", "copa" };
            List<Carta> cartas = new List<Carta>();

			foreach (string p in palos)
			{
				for (int i = 1; i <= 12; i++)
					cartas.Add(new Carta(i, p));
            }
            cartas.Add(new Carta("Comodin"));
			cartas.Add(new Carta("Comodin"));

            return cartas;
        }

        public static List<Carta> X40CartasEspañolas(){
			
			List<string> palos = new List<string>{"oro", "espada", "basto", "copa"};
			List<Carta> cartas = new List<Carta>();
			
			foreach(string p in palos){
				for(int i = 1; i <= 12; i++)
					if(i != 8 && i != 9)
                        cartas.Add(new Carta(i, p));
            }
			
			return cartas;
		}
	}

	public class Carta
	{
		private int valor;
		private string palo;

		public Carta(int valor, string palo)
		{
			this.valor = valor;
			this.palo = palo;
		}

		public Carta(string cartaEspecial)
		{
			this.palo = cartaEspecial;
			this.valor = -1;	
		}

		public string getPalo()
		{
			return palo;
		}
		public int getValor()
		{
			return valor;
		}

        public override string ToString()
        {
			return string.Format("{0} de {1}", valor, palo);
        }
    }
}
