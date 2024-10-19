
using System;
using System.Collections.Generic;

namespace Practica04
{
	public class Alumno: Persona, IAlumnoDecorable, IObservador, IObservado
	{
		//Atributos
		protected int legajo;
		protected double promedio;
		protected int calificacion;
		protected IEstrategiaCompAlumno estrategiaComp = new CompAlumnPorLegajo();
		
		//Unica instancia de random por fuera de metodos para evitar repeticion de datos aleatorios dentro de bucles.
		protected Random random = new Random();
		
		
		//Constructor
		public Alumno(string nombre, int dni, int legajo, double promedio): base(nombre, dni)
		{
			this.legajo = legajo;
			this.promedio = promedio;
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
		
		public int getCalificacion(){
			return this.calificacion;
		}
		public void setCalificacion(int c){
			this.calificacion = c;
		}
		
		//Metodos
		public virtual void prestarAtencion(){
			Console.WriteLine("Alumno: Prestando atención");
		}
		
		public virtual void distraerse(){
			string[] FRASES = {"Mirando el celular", "Dibujando en la carpeta", "Tirando aviones de papel"};
			string fraseAleatoria = FRASES[random.Next(0, 3)];
			Console.WriteLine("Alumno: " + fraseAleatoria);
			
			if(fraseAleatoria == "Tirando aviones de papel"){
				this.notificar();
			}
		}
		
		public virtual int responderPregunta(int pregunta){
			return random.Next(0,3);
		}
		
		public virtual string mostrarCalificacion(){
			return (this.nombre + "     " + this.calificacion);
		}

		//implementacion de IObservador
		public virtual void actualizar(IObservado o)
		{
			if (o is Profesor) {
				if (((Profesor)o).esta_hablando())
					this.prestarAtencion();
				else
					this.distraerse();
			}
			
		}
		
		//Implementacion de IObservado
		public List<IObservador> observadores = new List<IObservador>();

		
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
