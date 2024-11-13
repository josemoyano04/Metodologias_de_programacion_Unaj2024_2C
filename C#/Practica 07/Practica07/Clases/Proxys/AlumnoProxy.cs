
using System;

namespace Practica07
{
	public class AlumnoProxy: IAlumno, IObservado, IObservador
	{
		protected IAlumno alumnoReal = null;
		
		protected string nombre;
		protected int dni;
		protected int legajo;
		protected int promedio;
		protected int calificacion;
		
		private Random random = new Random();
		
		public AlumnoProxy(string nombre, int dni, int legajo, int promedio)
		{
			this.nombre = nombre;
			this.dni = dni;
			this.legajo = legajo;
			this.promedio = promedio;
		}

		//Implementacion de IAlumno
		public virtual string getNombre()
		{
			return ("Proxy " + this.nombre);
		}

		public virtual int getLegajo()
		{
			return this.legajo;
		}

		public virtual int getCalificacion()
		{
			return this.calificacion;
		}

		public virtual void setCalificacion(int c)
		{
			this.calificacion = c;
		}

		public virtual void prestarAtencion()
		{
			Console.WriteLine("Alumno proxy: Prestando atención");
		}

		public virtual void distraerse()
		{
			Console.WriteLine("Proxy");
			string[] FRASES = { "Mirando el celular", "Dibujando en la carpeta", "Tirando aviones de papel" };
			string fraseAleatoria = FRASES[random.Next(0, 3)];
			Console.WriteLine("Alumno: " + fraseAleatoria);

			if (fraseAleatoria == "Tirando aviones de papel")
			{
				this.notificar();
			}
		}

		public virtual int responderPregunta(int p)
		{
			return ((Alumno)obtenerAlumnoReal()).responderPregunta(p);
		}

		public virtual string mostrarCalificacion()
		{
			Console.WriteLine("Proxy");
			return (this.nombre + "     " + this.calificacion);
		}


		public virtual void agregarObservador(IObservador observador)
		{
			
			((Alumno)obtenerAlumnoReal()).agregarObservador(observador);
		}

		public virtual void eliminarObservador(IObservador observador)
		{
			((Alumno)obtenerAlumnoReal()).eliminarObservador(observador);
		}

		public virtual void notificar()
		{
			((Alumno)obtenerAlumnoReal()).notificar();
		}

		public virtual void actualizar(IObservado o)
		{
			((Alumno)obtenerAlumnoReal()).actualizar(o);
		}

		public bool sosIgual(Comparable comp)
		{
			return ((IAlumno)obtenerAlumnoReal()).sosIgual(comp);
		}
		public bool sosMenor(Comparable comp)
		{
			return ((IAlumno)obtenerAlumnoReal()).sosMenor(comp);
		}
		public bool sosMayor(Comparable comp)
		{
			return ((IAlumno)obtenerAlumnoReal()).sosMayor(comp);
		}		
		//Funciones auxiliares
		protected virtual IAlumno obtenerAlumnoReal(){
			if(alumnoReal == null)
				alumnoReal = new Alumno(this.nombre, this.dni, this.legajo, this.promedio);
			return alumnoReal;
		}
	}
}
