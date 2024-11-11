using System;
using System.Collections.Generic;

namespace Practica06
{
	public class JodeteJuego : JuegoDeCartasTemplate
	{
		
		private const int CARTAS_INICIALES_POR_JUGADOR = 7;
		
		public JodeteJuego()
		{
			this.mazo = MazosCartas.X50CartasEspañolas();
		}

		public override void repartirCartasIniciales()
		{
			Console.WriteLine("Repartiendo cartas iniciales...");
			
			foreach (Persona jugador in jugadores)
			{
				List<Carta> cartasDeJugador = new List<Carta>();
				for (int i = 0; i < CARTAS_INICIALES_POR_JUGADOR; i++)
					cartasDeJugador.Add(cartasMezcladas.Pop());
				cartasDeJuegadores.Add(jugador, cartasDeJugador);
			}
		}

		public override Persona checkGanador()
		{
			foreach (Persona jugador in jugadores)
			{
				if (cartasDeJuegadores[jugador].Count == 0) return jugador;
			}
			return null;
		}

		public override void jugarMano()
		{
			if (cartasDescartadas.Count == 0 && cartasMezcladas.Count > 0){
				cartasDescartadas.Push(cartasMezcladas.Pop());
				Console.WriteLine("Ultima carta en mazo de descarte: {0}", cartasDescartadas.Peek());
			}

			foreach(Persona jugador in jugadores){
				Carta cartaADescartar = descartarCartas(jugador);
				
				if(cartaADescartar != null){
					cartasDescartadas.Push(cartaADescartar);
					cartasDeJuegadores[jugador].Remove(cartaADescartar);
					continue;
				}
				if (cartasMezcladas.Count > 0) {
					tomarCartas(jugador);
					continue;
				}
				
				List<Carta> cartasParaMezclar = new List<Carta>();
				int cantCartasParaMezclar = cartasDescartadas.Count;
				for(int i = 0; i < cantCartasParaMezclar; i++)
					cartasParaMezclar.Add(cartasDescartadas.Pop());
				
				mezclarMazo(cartasParaMezclar);
			}
		}
		
		protected override Carta descartarCartas(Persona jugador)
		{
			if (cartasDeJuegadores[jugador].Count == 0 || cartasDescartadas.Count == 0)
				return null;
			
			Carta ultimaDescartada = cartasDescartadas.Peek();
			foreach (Carta c in cartasDeJuegadores[jugador]) {
				
				if(c.getPalo() == ultimaDescartada.getPalo() ||
				   c.getPalo() == "Comodin" ||
				   ultimaDescartada.getPalo() == "Comodin" ||
				   c.getValor() == ultimaDescartada.getValor()){
					
					if(c.getPalo() == "Comodin")
						Console.WriteLine("{0} descarta Comodin", jugador.getNombre());
					else
						Console.WriteLine("{0} descarta {1}", jugador.getNombre(), c);
					return c;
				}
			}
			return null;
		}
	}
}
