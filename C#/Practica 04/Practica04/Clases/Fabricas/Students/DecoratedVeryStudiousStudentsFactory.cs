
using System;

namespace Practica04
{
	public class DecoratedVeryStudiousStudentsFactory: StudentsFactory
	{
			public override AlumnoAdapter crearAleatorio()
		{
			//Utilizacion fabrica de alumnos aleatorios
			IAlumno alumno = (IAlumno)FabricaDeComparables.crearAleatorio(4);
			
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
			//Utilizacion fabrica de alumnos aleatorios
			IAlumno alumno = (IAlumno)FabricaDeComparables.crearPorTeclado(4);
			
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
