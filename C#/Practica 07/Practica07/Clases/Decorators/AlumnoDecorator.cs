﻿
using System;

namespace Practica07
{
	public abstract class AlumnoDecorator: IAlumno
	{
		protected IAlumno alumno;
		
		protected AlumnoDecorator(IAlumno alumno)
		{
			this.alumno = alumno;
		}
		
		public string getNombre()
		{
			return this.alumno.getNombre();
		}
		public int getLegajo()
		{
			return this.alumno.getLegajo();
		}
		public int getCalificacion()
		{
			return this.alumno.getCalificacion();
		}
		
		public void setCalificacion(int c){
			this.alumno.setCalificacion(c);
		}
		
		public void prestarAtencion(){
			this.alumno.prestarAtencion();
		}
		
		public void distraerse(){
			this.alumno.distraerse();
		}
		
		public int responderPregunta(int p){
			return this.alumno.responderPregunta(p);
		}
		
		public virtual string mostrarCalificacion()
		{
			return this.alumno.mostrarCalificacion();
		}

		public bool sosIgual(Comparable comp)
		{

			return this.alumno.sosIgual(comp);
		}

		public bool sosMenor(Comparable comp)
		{
			return this.alumno.sosMenor(comp);
			
		}

		public bool sosMayor(Comparable comp)
		{
			return this.alumno.sosMayor(comp);
			
		}
	}
}
