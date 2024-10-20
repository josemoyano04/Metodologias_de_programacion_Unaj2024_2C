
using System;

namespace Practica05
{
    public class AlumnoDecoradoRecuadro : AlumnoDecorator
    {
        public AlumnoDecoradoRecuadro(IAlumno alumno) : base(alumno)
        {
            this.alumno = alumno;
        }

        public string mostrarCalificacio()
        {
            string mensajePravio = alumno.mostrarCalificacion();
            string mensaje = string.Format("************************************\n" +
                                           "*  {0}\n" +
                                           "************************************",
                                           alumno.mostrarCalificacion());
            return mensaje;
        }

        public override string mostrarCalificacion()
        {
            const int TAMAÑO_MAX = 40;
            string mensajePrevio = alumno.mostrarCalificacion();

            string bordeHorizontalRec = "".PadLeft(TAMAÑO_MAX, '*');
            int tamañoSobrantePorLado = ((TAMAÑO_MAX - mensajePrevio.Length) / 2 - 1);
            string textoCentrado = mensajePrevio.PadLeft(tamañoSobrantePorLado + mensajePrevio.Length, ' ');
            textoCentrado = textoCentrado.PadRight(tamañoSobrantePorLado + textoCentrado.Length, ' ');

            string mensaje = string.Format("{0}\n*{1}*\n{0}", bordeHorizontalRec, textoCentrado);


            return mensaje;
        }
    }
}
