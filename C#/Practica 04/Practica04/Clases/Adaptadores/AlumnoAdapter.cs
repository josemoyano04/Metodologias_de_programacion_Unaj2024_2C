
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
			this.alumno.SetCalificacion(score);
		}
		public string showResult()
		{
			return this.alumno.mostrarCalificacion();
		}
		public bool equals(Student student)
		{
			return this.alumno.sosIgual((Comparable)student);
		}
		public bool lessThan(Student student)
		{
			return this.alumno.sosMenor((Comparable)student);
		}
		public bool greaterThan(Student student)
		{
			return this.alumno.sosMayor((Comparable)student);
		}
	}
}
