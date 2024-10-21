﻿using System;
using MDPI;

namespace Practica05
{
	public class Aula //Receptor
	{
		private Teacher teacher = null;
		
		public Aula(){}
		
		public void comenzar(){
			Console.WriteLine("Comenzando...");
			if(teacher == null)
				teacher = new Teacher();
		}
		
		public void nuevoAlumno(AlumnoAdapter alumno){
			if(teacher == null)
				comenzar();
			teacher.goToClass((Student)alumno);
		}
		
		public void claseLista(){
			teacher.teachingAClass();
		}
	}
}