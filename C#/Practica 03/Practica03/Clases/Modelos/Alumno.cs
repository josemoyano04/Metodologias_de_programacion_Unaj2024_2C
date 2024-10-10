
using System;

namespace Practica03
{
	public class Alumno: Persona
	{
		//Atributos
		private int legajo;
		private double promedio;
		private IEstrategiaCompAlumno estrategiaComp;
		
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
		public void prestarAtencion(){
			Console.WriteLine("Prestando atención");
		}
		
		public void distraerse(){
			string[] FRASES = {"Mirando el celular", "Dibujando en la carpeta", "Tirando aviones de papel"};
			Random r = new Random();
			int fraseAleatoria = r.Next(0, 3);
			Console.WriteLine(FRASES[fraseAleatoria]);
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
