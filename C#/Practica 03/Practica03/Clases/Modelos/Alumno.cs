
using System;
using System.Collections.Generic;

namespace Practica03
{
	public class Alumno: Persona, IObservador, IObservado
	{
		//Atributos
		protected int legajo;
		protected double promedio;
		protected IEstrategiaCompAlumno estrategiaComp;
		
		protected List<IObservador> observadores = new List<IObservador>();
		
		//Unica instancia de random por fuera de metodos para evitar repeticion de datos aleatorios dentro de bucles.
		protected Random random = new Random();
		
		
		//Constructor
		public Alumno(string nombre, int dni, int legajo, double promedio): base(nombre, dni)
		{
			this.legajo = legajo;
			this.promedio = promedio;
			this.estrategiaComp = new CompAlumnPorLegajo();
		}
		
		//Getters y Setters
		public int getLegajo(){
			return legajo;
		}
		
		public double getPromedio(){
			return promedio;
		}
		
		public void setLegajo(int legajo){
			this.legajo = legajo;
		}
		
		public void setPromedio(double promedio){
			this.promedio = promedio;
		}
		
		public void SetEstrategia(IEstrategiaCompAlumno estrategia){
			estrategiaComp = estrategia;
		}
		
		
		//Metodos
		public virtual void prestarAtencion(){
			Console.WriteLine("Prestando atención");
		}
		
		public virtual void distraerse(){
			string[] FRASES = {"Mirando el celular", "Dibujando en la carpeta", "Tirando aviones de papel"};
			int fraseAleatoria = random.Next(0, 3);
			Console.WriteLine(FRASES[fraseAleatoria]);
			
			//Ejercicio 15 Opcional
			if(FRASES[fraseAleatoria] == "Tirando aviones de papel")
				this.notificar();
			
		}

		//implementacion de IObservador
		public virtual void actualizar(IObservado o)
		{
			try {
				if(((Profesor)o).esta_hablando())
					this.prestarAtencion();
				else
					this.distraerse();
			} catch (InvalidCastException) {} //Control de errores cuando se actualiza desde una instancia distinta de profesor
			
		}

		//Implementacion de IObservado
		public virtual void agregarObservador(IObservador observador)
		{
			observadores.Add(observador);
		}
		public virtual void eliminarObservador(IObservador observador)
		{
			observadores.Remove(observador);
		}
		public virtual void notificar()
		{
			foreach (IObservador o in observadores) {
				o.actualizar(this);
			}
		}
		
		//Reimplementacion de Comparable
		public override bool sosIgual(Comparable comp)
		{
			try {
				return estrategiaComp.sosIgual(this, (Alumno)comp);
			} catch (InvalidCastException) {
				return false;
			}
		}
		
		public override bool sosMenor(Comparable comp)
		{
			return estrategiaComp.sosMenor(this, (Alumno)comp);
		}
		
		public override bool sosMayor(Comparable comp)
		{
			return estrategiaComp.sosMayor(this, (Alumno)comp);
		}
		
		
		//Overrides
		public override string ToString()
		{
			return string.Format("(Alumno -Nombre: {0}, -Dni: {1}, -Legajo: {2}, -Promedio: {3})",
			                     nombre, dni, legajo, promedio);
		}
	}
}
