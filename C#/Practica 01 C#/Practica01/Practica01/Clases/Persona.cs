
using System;

namespace Practica01
{
	public class Persona: Comparable
	{
		//Atributos
		private string nombre;
		private int dni;
		
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
		public bool sosIgual(Comparable comp)
		{
			if (this.dni == ((Persona)comp).getDni())
				return true;
			return false;
		}
		
		public bool sosMenor(Comparable comp)
		{
			if (this.dni < ((Persona)comp).getDni())
				return true;
			return false;
		}
		
		public bool sosMayor(Comparable comp)
		{
			if (this.dni > ((Persona)comp).getDni())
				return true;
			return false;
		}
		
		public override string ToString()
		{
			return string.Format("Persona\n-Nombre: {0}\n-Dni: {1}", this.nombre, this.dni);
		}
	}
}
