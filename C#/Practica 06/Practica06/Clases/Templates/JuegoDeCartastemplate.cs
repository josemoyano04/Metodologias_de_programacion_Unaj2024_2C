using System;
using System.Collections.Generic;
using System.Threading;

namespace Practica06
{
	public abstract class JuegoDeCartasTemplate
	{
		protected List<Persona> jugadores = new List<Persona>();
		protected Dictionary<Persona, List<Carta>> cartasDeJuegadores = new Dictionary<Persona, List<Carta>>();
		protected List<Carta> mazo; //Mazo ordenado con cartas a utilizar en cada juego
		protected Stack<Carta> cartasMezcladas = new Stack<Carta>(); //Mazo mezclado y listo para utilizar en la partida
		protected Stack<Carta> cartasDescartadas = new Stack<Carta>(); //Mazo de cartas descartadas por cada jugador

		protected Persona ganadorRonda = null;
		protected Persona ganadorPartida = null;
		protected int cantVictorias = 1;
		
		public void comenzarJuego(params Persona[] jugador)
		{
//			Contador de partidas ganadas
			Dictionary<Persona, int> partidasGanadasJugador = new Dictionary<Persona, int>();
			
			Console.WriteLine("Iniciando juego...");
			
			setJugadores(jugador);
			Console.WriteLine("~~~~~~~~Jugadores~~~~~~~~");
			foreach (Persona j in jugadores) {
				Console.WriteLine("-> {0}", j.getNombre());
				partidasGanadasJugador.Add(j, 0);
			}
			Console.WriteLine("~~~Cantidad de rondas~~~");
			Console.WriteLine("Victorias minimas: {0}", cantVictorias);
			Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~\n");
			
			
			
			bool  ganadorExiste = false;
			
			while (!ganadorExiste) {
				//Verificacion de que algun jugador haya alcanzado las victorias minimas
				
				jugarPartida();
				partidasGanadasJugador[ganadorRonda]++;
				
				
				for (int i = 0; i < jugadores.Count; i++) {
					if(partidasGanadasJugador[jugadores[i]] >= cantVictorias){
						ganadorExiste = true;
						ganadorPartida = jugadores[i];
						break;
					}
				}
				
				ganadorRonda = null; //Reinicio de ganadorRonda para proxima iteracion
			}
			
			Console.WriteLine("~~~~~Ganador de la partida~~~~~");
			Console.WriteLine("jugador: {0}", ganadorPartida.getNombre());
			Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
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
			Thread.Sleep(1); //Espera de 1 milisegindo para evitar que el Random repita numeros
			cartasMezcladas.Clear();
			Console.WriteLine("Mezclando mazo..");
			Random random = new Random();
			
			//Mazo auxiliar que contiene una copia del mazo original para posteriormente restaurarlo
			List<Carta> mazoAux = new List<Carta>();
			mazoAux.AddRange(mazo);
			
			int posRandom;
			
			if(mazo == null)
				return;
			
			//Mezclado de cartas
			for (int i = mazo.Count -1; i >= 0; i--) {
				posRandom = random.Next(0, i);
				cartasMezcladas.Push(mazo[posRandom]);
				mazo.RemoveAt(posRandom);
			}
			
			//Restauro el mazo
			mazo.AddRange(mazoAux);

		}
		
		private void jugarPartida(){
			mezclarMazo(this.mazo);
			repartirCartasIniciales();
			
			//Bucle del una partida del juego
			while(ganadorRonda == null){
				jugarMano();
				ganadorRonda = checkGanador();
			}
			
			//Una vez encontrado un ganadorRonda, se limpian todas las colecciones de cartas y variables de uso en tiempo de compilacion
			cartasMezcladas.Clear();
			cartasDescartadas.Clear();
			cartasDeJuegadores.Clear();
			Console.WriteLine("\n~~~~ Ganador de ronda: {0} ~~~~\n", ganadorRonda.getNombre());
		}
		
		//Metodos abstractos:
		public abstract void repartirCartasIniciales();
		public abstract void jugarMano();
		public abstract Persona checkGanador();
		
		
	}
}
