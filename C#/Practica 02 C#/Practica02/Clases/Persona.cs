﻿
using System;

namespace Practica02
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
			return nombre;
		}
		
		public int getDni(){
			return dni;
		}
		
		
		//Implementacion de Comparable
		public virtual bool sosIgual(Comparable comp)
		{
			try {
				
				if (dni == ((Persona)comp).getDni())
					return true;
				
			} catch (InvalidCastException) {}
			return false;
		}
		
		public virtual bool sosMenor(Comparable comp)
		{
			return dni < ((Persona)comp).getDni();
		}
		
		public virtual bool sosMayor(Comparable comp)
		{
			return dni > ((Persona)comp).getDni();
		}
		
		
		//Overrides
		public override string ToString()
		{
			return string.Format("Persona\n-Nombre: {0}\n-Dni: {1}", nombre, dni);
		}
	}
}
