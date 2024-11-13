using System;
using System.Collections.Generic;

namespace Practica07
{
	public class NueveJuego: JuegoDeCartasTemplate
	{
		
		private const int CARTAS_INICIALES_POR_JUGADOR = 2;
		
		public NueveJuego(int cantPartidas)
		{
			this.mazo = MazosCartas.X40CartasEspañolas();
			this.cantVictorias = cantPartidas;
			
		}

		public override void repartirCartasIniciales()
		{
			foreach (Persona j in jugadores) {
				List<Carta> cartasJugador = new List<Carta>();
				
				for (int i = 0; i < CARTAS_INICIALES_POR_JUGADOR; i++) {
					cartasJugador.Add(cartasMezcladas.Pop());
				}
				cartasDeJuegadores.Add(j, cartasJugador);
			}
		}

		public override void jugarMano()
		{
			//Este juego no posee ninguna logica para jugar mano, ya que solo
			//se comparan los valores de las cartas de ambos jugadores
		}

		public override Persona checkGanador()
		{
			List<int> ValoresDeCartasNoValidas = new List<int>{10, 11, 12};
			List<int> puntajes = new List<int>();
			List<Carta> cartasJugadorActual;
			
			foreach (Persona j in jugadores) {
				cartasJugadorActual = cartasDeJuegadores[j];
				int puntajeSumado = 0;
				foreach (Carta c in cartasJugadorActual) {
					//Si la carta no es un 10, 11, o 12, se suma al puntaje del jugador
					if(!ValoresDeCartasNoValidas.Contains(c.getValor()))
						puntajeSumado += c.getValor();
					
					//En caso de que el puntaje supere 10, se le resta 10 para siempre tener
					//un puntaje menor a dicho numero
					if (puntajeSumado >= 10) {
						puntajeSumado -= 10;
					}
				}
				Console.WriteLine("{0} {1}puntos", j.getNombre(), puntajeSumado);
				puntajes.Add(puntajeSumado);
			}
			
			//Obtencion del puntaje más cercano a nueve
			int puntajeMasCercano = puntajes[0]; //Por defecto el primero es el mas cercano
			int distanciaANueve = 9 - puntajeMasCercano;
			Persona ganador = jugadores[0]; //por defecto es el primer jugador (dueño del puntaje por defecto)
			
			for (int i = 1; i < puntajes.Count; i++) {
				int distanciaANueveActual = 9 - puntajes[i];
				if(distanciaANueveActual  < distanciaANueve){
					puntajeMasCercano = puntajes[i];
					ganador = jugadores[i];
				}
				if(distanciaANueveActual == distanciaANueve){ //Empate
					Console.WriteLine("Empate, ganador random");
					Random random = new Random();
					ganador = jugadores[random.Next(jugadores.Count)];
				}
			}
			
			return ganador;
		}
	}
}
