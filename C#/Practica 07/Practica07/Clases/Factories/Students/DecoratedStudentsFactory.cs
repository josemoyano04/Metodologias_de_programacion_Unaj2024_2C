
using System;

namespace Practica07
{
	public class DecoratedStudentsFactory: StudentsFactory
	{
		public override AlumnoAdapter crearAleatorio()
		{
			string nombreAl = aleatorio.stringAleatorio(5);
			int dniAl = aleatorio.numeroAleatorio(1000000);
			int legajoAl = aleatorio.numeroAleatorio(10000);
			int promedioAl = aleatorio.numeroAleatorio(11);
			
			IAlumno alumno = new AlumnoProxy(nombreAl, dniAl, legajoAl, promedioAl);
			
			//Aplicacion de decoradores
			AlumnoDecoradoLegajo alumnoConLegajo = new AlumnoDecoradoLegajo(alumno);
			AlumnoDecoradoCalificacionEnLetras alumnoCalificadoLetras = new AlumnoDecoradoCalificacionEnLetras(alumnoConLegajo);
			AlumnoDecoradoEstadoPromocion alumnoEstadoProm = new AlumnoDecoradoEstadoPromocion(alumnoCalificadoLetras);
			AlumnoDecoradoRecuadro alumnoRecuadro = new AlumnoDecoradoRecuadro(alumnoEstadoProm);
			
			//Creacion del Alumno adaptado con los decoradores previamente aplicados
			AlumnoAdapter student = new AlumnoAdapter(alumnoRecuadro);
			
			return student;
		}

		
		public override AlumnoAdapter crearPorteclado()
		{
			string nombreTec = teclado.stringPorTeclado();
			int dniTec = teclado.numerosPorTeclado();
			int legajoTec = teclado.numerosPorTeclado();
			int promedioTec = teclado.numerosPorTeclado();
			
			IAlumno alumno = new AlumnoProxy(nombreTec, dniTec, legajoTec, promedioTec);
			
			//Aplicacion de decoradores
			AlumnoDecoradoLegajo alumnoConLegajo = new AlumnoDecoradoLegajo(alumno);
			AlumnoDecoradoCalificacionEnLetras alumnoCalificadoLetras = new AlumnoDecoradoCalificacionEnLetras(alumnoConLegajo);
			AlumnoDecoradoEstadoPromocion alumnoEstadoProm = new AlumnoDecoradoEstadoPromocion(alumnoCalificadoLetras);
			AlumnoDecoradoRecuadro alumnoRecuadro = new AlumnoDecoradoRecuadro(alumnoEstadoProm);
			
			//Creacion del Alumno adaptado con los decoradores previamente aplicados
			AlumnoAdapter student = new AlumnoAdapter(alumnoRecuadro);
			
			return student;
		}
	}
}
