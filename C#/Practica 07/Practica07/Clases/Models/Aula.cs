using System;
using MDPI;

namespace Practica07
{
	public class Aula
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
