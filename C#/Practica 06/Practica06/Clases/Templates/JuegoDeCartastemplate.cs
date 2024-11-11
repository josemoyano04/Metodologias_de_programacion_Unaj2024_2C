using System;
using System.Collections.Generic;

namespace Practica06
{
	public abstract class JuegoDeCartasTemplate
	{
		protected List<Persona> jugadores = new List<Persona>();
		protected Dictionary<Persona, List<Carta>> cartasDeJuegadores = new Dictionary<Persona, List<Carta>>();
		protected Dictionary<Persona, int> puntosDeJuegadores = new Dictionary<Persona, int>();

		protected List<Carta> mazo;
		protected Stack<Carta> cartasMezcladas;
		protected Stack<Carta> cartasDescartadas;

		protected Persona ganador = null;

        protected void comenzarJuego(params Persona[] jugador)
        {
            setJugadores(jugador);
            mezclarMazo();
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
        }
        protected void setJugadores(params Persona[] jugador){
			foreach (Persona j in jugador) {
				jugadores.Add(j);
			}
		}

		
		protected void tomarCartas(Persona jugador){
			cartasDeJuegadores[jugador].Add(cartasMezcladas.Pop());
		}
		protected Carta descartarCartas(Persona jugador){
			Random random = new Random();
			int posCartaDescartada = random.Next(0, cartasDeJuegadores[jugador].Count -1);
			Carta cartaDescartada = cartasDeJuegadores[jugador][posCartaDescartada];
			cartasMezcladas.Push(cartaDescartada);
			cartasDeJuegadores[jugador].Remove(cartaDescartada);

			return cartaDescartada;
		}
		
		
		protected void mezclarMazo()
		{
			Random random = new Random();
			int contCartas = 0;
			int posCambio;

			//Barajado
			foreach(Carta carta in mazo)
			{
				posCambio = random.Next(contCartas, mazo.Count -1);

				//Intercambio de cartas
				Carta temp = mazo[contCartas];
				mazo[contCartas] = mazo[posCambio];
				mazo[posCambio] = temp;
				contCartas++;
			}

			//Agregado de cada carta a una pila de cartas
			if(cartasMezcladas != null) cartasMezcladas.Clear();
			foreach(Carta carta in mazo)
			{
				cartasMezcladas.Push(carta);
			}
		}
		
		//Metodos abstractos:
		public abstract void repartirCartasIniciales();
		public abstract void jugarMano();
		public abstract Persona checkGanador();
		
		
	}
}
