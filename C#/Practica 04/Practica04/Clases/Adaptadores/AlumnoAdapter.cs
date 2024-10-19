
using System;
using MDPI;

namespace Practica04
{
	public class AlumnoAdapter: Student
	{
		private Alumno alumno;
		
		public AlumnoAdapter(Alumno a)
		{
			this.alumno = a;
		}
		
		public Alumno GetAlumno(){
			return this.alumno;
		}
		//Implementacion de Student
		
		public string getName()
		{
			return this.alumno.getNombre();
		}
		public int yourAnswerIs(int question)
		{
			return this.alumno.responderPregunta(question);
		}
		public void setScore(int score)
		{
			this.alumno.setCalificacion(score);
		}
		public string showResult()
		{
			return this.alumno.mostrarCalificacion();
		}
		public bool equals(Student student)
		{
			AlumnoAdapter studentComparado = (AlumnoAdapter)student;
			bool sonIguales = alumno.getCalificacion() == (studentComparado.GetAlumno()).getCalificacion();
			return sonIguales;
			
		}
		public bool lessThan(Student student)
		{
			AlumnoAdapter studentComparado = (AlumnoAdapter)student;
			bool esMenor = alumno.getCalificacion() < (studentComparado.GetAlumno()).getCalificacion();
			return esMenor;
			
		}
		public bool greaterThan(Student student)
		{
			AlumnoAdapter studentComparado = (AlumnoAdapter)student;
			bool esMayor = alumno.getCalificacion() > (studentComparado.GetAlumno()).getCalificacion();
			return esMayor;
		}
	}
}
