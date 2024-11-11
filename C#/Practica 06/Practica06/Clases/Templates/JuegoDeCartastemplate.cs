using System;
using System.Collections.Generic;

namespace Practica06
{
	public abstract class JuegoDeCartasTemplate
	{
		List<Persona> jugadores = new List<Persona>();
		Persona ganador = null;
		
		protected void setJugadores(params Persona[] jugador){
			foreach (Persona j in jugador) {
				jugadores.Add(j);
			}
		}
		
		protected void comenzarJuego(params Persona[] jugador){
			setJugadores(jugador); 
			mezclarMazo();
			repartirCartasIniciales();
			
			while (ganador == null) {
				jugarMano();
				ganador = checkGanador();
			}
			
			
		}
		
		protected void jugarMano(){
			foreach (Persona j in jugadores) {
				Console.WriteLine("Jugador:{0} → {1}", j.getNombre(), tomarCartas());
				Console.WriteLine("Jugador:{0} → {1} ", j.getNombre(), descartarCartas());
			}
		}
		protected string tomarCartas(){
			return "tomando carta";
		}
		protected string descartarCartas(){
			return "descartando carta";
		}
		
		
		public abstract void mezclarMazo();
		public abstract void repartirCartasIniciales();
		public abstract Persona checkGanador();
		
		
	}
}
