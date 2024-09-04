
using System;

namespace Practica01
{
	public class Persona: Comparable
	{
		//Atributos
		protected string nombre;
		protected int dni;
		
		//Constructor
		public Persona(string nombre, int dni)
		{
			this.nombre = nombre;
			this.dni = dni;
		}
		
		//Getters
		public string getNombre(){
			return this.nombre;
		}
		
		public int getDni(){
			return this.dni;
		}
		
		
		//Implementacion de Comparable
		public virtual bool sosIgual(Comparable comp)
		{
			return (this.dni == ((Alumno)comp).getDni());
		}
		
		public virtual bool sosMenor(Comparable comp)
		{
			return (this.dni < ((Alumno)comp).getDni());
		}
		
		public virtual bool sosMayor(Comparable comp)
		{
			return (this.dni > ((Alumno)comp).getDni());
		}
		
		
		//Overrides
		public override string ToString()
		{
			return string.Format("Persona\n-Nombre: {0}\n-Dni: {1}", this.nombre, this.dni);
		}
	}
}
