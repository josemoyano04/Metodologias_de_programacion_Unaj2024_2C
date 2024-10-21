
using System;

namespace Practica06
{
    public class AlumnoDecoradoLegajo : AlumnoDecorator
    {
        public AlumnoDecoradoLegajo(IAlumno alumno) : base(alumno)
        {
            this.alumno = alumno;
        }

        public override string mostrarCalificacion()
        {
        	string mensajePrevio = this.alumno.mostrarCalificacion();
			string mensaje = string.Format("({0}){1}", alumno.getLegajo(), mensajePrevio);
            
			return mensaje;
        }
    }
}
