
using System;
using System.Collections.Generic;

namespace Practica03
{

	public class Profesor: Persona, IObservado, IObservador
	{
		//Atributos
		private List<IObservador> observadores = new List<IObservador>();
		private int antiguedad;
		
		//Flags
		private bool hablando = false;
		private bool notificando = false;
		
		//Constructor
		public Profesor(string nombre, int dni, int a): base(nombre, dni)
		{
			this.antiguedad = a;
		}
		
		//Getter y Setter
		public int GetAntigueda(){
			return this.antiguedad;
		}
		public void SetAntiguedad(int a){
			this.antiguedad = a;
		}
		
		public bool esta_hablando(){
			return hablando;
		}
		
		//Metodos
		public void hablarALaClase(){
			if (!notificando)
			{
				notificando = true; // Activamos el flag
				Console.WriteLine("Hablando de algún tema");
				this.hablando = true;
				this.notificar();
				notificando = false; // Desactivamos el flag
			}
		}
		public void escribirEnElPizarron(){
			if (!notificando)
			{
				notificando = true; // Activamos el flag
				Console.WriteLine("Escribiendo en el pizarrón");
				this.hablando = false;
				this.notificar();
				notificando = false; // Desactivamos el flag
			}
		}
		public void hacerSilencio(){
			Console.WriteLine("Silencio, no se distraigan");
		}
		
		//Implementacion de IObservado
		
		public void agregarObservador(IObservador observador)
		{
			observadores.Add(observador);
		}
		public void eliminarObservador(IObservador observador)
		{
			observadores.Remove(observador);
		}
		public void notificar()
		{
			foreach (IObservador o in observadores) {
				o.actualizar(this);
			}
		}

		//Implementacion de IObservador
		public void actualizar(IObservado o)
		{
			this.hacerSilencio();
		}
		
		//Override ToString
		public override string ToString()
		{
			return string.Format("(Profesor -Nombre: {0}, -Dni: {1}, -Antigüedad: {2})",
			                     nombre, dni, antiguedad);
		}

	}
}
