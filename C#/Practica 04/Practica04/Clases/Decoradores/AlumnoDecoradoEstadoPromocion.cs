
using System;
using System.Runtime.CompilerServices;

namespace Practica04
{
	public class AlumnoDecoradoEstadoPromocion: AlumnoDecorator
	{
		//Constructor
		public AlumnoDecoradoEstadoPromocion(IAlumnoDecorable alumno): base(alumno)
		{
			this.alumno = alumno;
		}
		
		//Variables
		string[] ESTADOS_CALIFICACIO = {"DESAPROBADO", "APROBADO", "PROMOCIÓN"};
		int estadoCalificacionDeAlumno = -1;
		
		//Retorna un mensaje con el nombre del alumno, calificacion, y estado de promocion
		public override string mostrarCalificacion()
		{
			setEstadoCalificacio();
			
			string estado = ESTADOS_CALIFICACIO[estadoCalificacionDeAlumno];
			string mensaje = string.Format("{0}     {1}({2})", alumno.getNombre(), 
			                               alumno.getCalificacion(), estado);
			
			return mensaje;
			
		}
		
		
		//Funcion auxiliar
		//Setea el estado de calificacion del alumno dependiedo de su calificacion
		public void setEstadoCalificacio(){
			int calificacion = alumno.getCalificacion();
			
			if(calificacion >= 0 && calificacion < 4)
				this.estadoCalificacionDeAlumno = 0;
			else if(calificacion >= 4 && calificacion < 7)
				this.estadoCalificacionDeAlumno = 1;
			else if(calificacion >= 7 && calificacion <= 10)
				this.estadoCalificacionDeAlumno = 2;
			else
				this.estadoCalificacionDeAlumno = -1; //Estado nulo
		}
	}
}
