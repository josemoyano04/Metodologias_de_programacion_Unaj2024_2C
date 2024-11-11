using System;
using System.Collections.Generic;

namespace Practica06.Clases.Juegos_de_carta
{
    public class JodeteJuego : JuegoDeCartasTemplate
    {
        private List<Carta> mazo = MazosCartas.X50CartasEspañolas();
        private const int CARTAS_INICIALES_POR_JUGADOR = 7;

        public override void repartirCartasIniciales()
        {
            List<Carta> cartasDeJugador = new List<Carta>();
            foreach (Persona jugador in jugadores)
            {
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
            cartasDescartadas.Push(cartasMezcladas.Pop());

            foreach(Persona jugador in jugadores)
            {
                if (cartasDeJuegadores[jugador].Count == 0)
                    return;

                
            }
        }
    }
}
