
using System;
using System.Collections.Generic;

namespace Practica06
{

	public class Profesor: Persona, IObservado, IObservador
	{
		//Atributos
		private List<IObservador> observadores = new List<IObservador>();
		private int antiguedad;
		
		//Flags
		private bool hablando = false;

		
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

			Console.WriteLine("Profesor: Hablando de algún tema");
			this.hablando = true;
			this.notificar();

		}
		
		public void escribirEnElPizarron(){

			Console.WriteLine("Profesor: Escribiendo en el pizarrón");
			this.hablando = false;
			this.notificar();
			
		}
	
	//Ejercicio 15 opcional
	public void hacerSilencio(){
		Console.WriteLine("Profesor: Silencio, no se distraigan");
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
