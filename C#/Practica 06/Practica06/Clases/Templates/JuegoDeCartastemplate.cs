using System;
using System.Collections.Generic;

namespace Practica06
{
	public abstract class JuegoDeCartasTemplate
	{
		protected List<Persona> jugadores = new List<Persona>();
		protected Dictionary<Persona, List<Carta>> cartasDeJuegadores = new Dictionary<Persona, List<Carta>>();
		

		protected List<Carta> mazo; //Mazo ordenado con cartas a utilizar en cada juego
		protected Stack<Carta> cartasMezcladas = new Stack<Carta>(); //Mazo mezclado y listo para utilizar en la partida
		protected Stack<Carta> cartasDescartadas = new Stack<Carta>(); //Mazo de cartas descartadas por cada jugador

		protected Persona ganador = null;

		public void comenzarJuego(params Persona[] jugador)
		{
			Console.WriteLine("Iniciando juego...");
			
			setJugadores(jugador);
			Console.WriteLine("~~~Jugadores~~~");
			foreach (Persona j in jugadores) {
				Console.WriteLine("-> {0}", j.getNombre());
			}
			Console.WriteLine("~~~~~~~~~~~~~~");
			
			mezclarMazo(this.mazo);
			repartirCartasIniciales();

			while (ganador == null)
			{
				
				jugarMano();
				
				ganador = checkGanador();
			}

			//Una vez encontrado un ganador, se limpian todas las listas y pilas de cartas
			cartasMezcladas.Clear();
			cartasDescartadas.Clear();
			foreach(Persona j in jugadores)
			{
				cartasDeJuegadores[j].Clear();
			}
			
			Console.WriteLine("Ganador: {0}", ganador  );
		}
		
		public void setJugadores(params Persona[] jugador){
			foreach (Persona j in jugador) {
				jugadores.Add(j);
//				cartasDeJuegadores.Add(j, new List<Carta>()); //inicialiciacion de registro de cartas de. jugador
			}
		}

		protected void tomarCartas(Persona jugador){
			cartasDeJuegadores[jugador].Add(cartasMezcladas.Pop());
			Console.WriteLine("{0} toma una carta", jugador.getNombre());
		}
		protected virtual Carta descartarCartas(Persona jugador){ //Por defecto se descarta una carta random
			Random random = new Random();
			int posCartaDescartada = random.Next(0, cartasDeJuegadores[jugador].Count -1);
			Carta cartaDescartada = cartasDeJuegadores[jugador][posCartaDescartada];
			cartasMezcladas.Push(cartaDescartada);
			cartasDeJuegadores[jugador].Remove(cartaDescartada);
			
			if(cartaDescartada.getPalo() == "Comodin")
				Console.WriteLine("{0} descarta Comodin", jugador.getNombre());
			else
				Console.WriteLine("{0} descarta {1}", jugador.getNombre(), cartaDescartada);
			return cartaDescartada;
		}
		
		
		protected void mezclarMazo(List<Carta> mazo)
		{
			Console.WriteLine("Mezclando mazo..");
			Random random = new Random();
			List<Carta> mazoAux = mazo;
			int posRandom;
			
			if(mazo == null)
				return;
			
			//Mezclado de cartas
			for (int i = mazo.Count -1; i >= 0; i--) {
				posRandom = random.Next(0, i);
				cartasMezcladas.Push(mazoAux[posRandom]);
				mazoAux.RemoveAt(posRandom);
			}

		}
		
		//Metodos abstractos:
		public abstract void repartirCartasIniciales();
		public abstract void jugarMano();
		public abstract Persona checkGanador();
		
		
	}
}
