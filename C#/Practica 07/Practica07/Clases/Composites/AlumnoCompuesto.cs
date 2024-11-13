
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;

namespace Practica07
{
	public class AlumnoCompuesto: IAlumno
	{
		private List<IAlumno> hijos = new List<IAlumno>();
		
		public AlumnoCompuesto(){}
		
		public void agregarHijo(IAlumno hijo){
			hijos.Add(hijo);
		}
		
		public void eliminarHijo(IAlumno hijo){
			hijos.Remove(hijo);
		}
		
		#region IAlumno implementation

		public string getNombre()
		{
			List<string> nombres = new List<string>();
			
			foreach (IAlumno hijo in hijos){
				nombres.Add(hijo.getNombre());
			}
			
			return string.Join(", ", nombres);
		}

		public int getLegajo()
		{
			throw new NotImplementedException();
		}

		public int getCalificacion()//Obtiene la mayor calificiacion
		{
			int maxCalificacion = 0;
			
			foreach (IAlumno a in hijos) {
				if(a.getCalificacion() > maxCalificacion) 
					maxCalificacion = a.getCalificacion();
			}
			
			return maxCalificacion;
		}

		public void setCalificacion(int c)
		{
			foreach (IAlumno a in hijos) {
				a.setCalificacion(c);
			}
		}

		public void prestarAtencion()
		{
			foreach (IAlumno a in hijos) {
				a.prestarAtencion();
			}
		}

		public void distraerse()
		{
			foreach (IAlumno a in hijos) {
				a.distraerse();
			}
		}

		public int responderPregunta(int p)
		{
			//Contadores de respuestas
			int cont1 = 0;
			int cont2 = 0;
			int cont3 = 0;
			
			foreach (IAlumno a in hijos)
			{
				int resp = a.responderPregunta(p);
				
				switch(resp)
				{
					case 1:
						cont1++; break;
					case 2:
						cont2++; break;
						
					case 3:
						cont3++; break;
						
				}
			}
			
			
			int maxVotos = Math.Max(cont1, Math.Max(cont2, cont3));

			List<int> respMasVotada = new List<int>();

			if (cont1 == maxVotos) respMasVotada.Add(1);
			if (cont2 == maxVotos) respMasVotada.Add(2);
			if (cont3 == maxVotos) respMasVotada.Add(3);

			
			Random random = new Random();
			return respMasVotada[random.Next(respMasVotada.Count)];
		}
		

		public string mostrarCalificacion()
		{
			string calificaciones = "";
			foreach (IAlumno hijo in hijos)
			{
				calificaciones += "\n"+hijo.mostrarCalificacion();
			}
			return calificaciones;
			
		}

		#endregion

		#region Comparable implementation

		public bool sosIgual(Comparable comp)
		{
			bool algunoEsIgual = false;
			
			foreach (IAlumno a in hijos) {
				if(a.sosIgual(comp))
					algunoEsIgual = true; break;
				
			}
			return algunoEsIgual;
		}

		public bool sosMenor(Comparable comp)
		{
			foreach (IAlumno a in hijos){
				if(!a.sosMenor(comp))
					return false;
			}
			return true;
		}
		

		public bool sosMayor(Comparable comp)
		{
			foreach (IAlumno a in hijos) {
				if(!a.sosMayor(comp))
					return false;
			}
			return true;
		}

		#endregion
	}
}
