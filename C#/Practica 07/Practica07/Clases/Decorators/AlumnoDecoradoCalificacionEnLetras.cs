
using System;

namespace Practica07
{
    public class AlumnoDecoradoCalificacionEnLetras : AlumnoDecorator
    {
        private Diccionario numerosEnLetras = crearNumeroLetra();

        public AlumnoDecoradoCalificacionEnLetras(IAlumno alumno) : base(alumno)
        {
            this.alumno = alumno;
        }



        public override string mostrarCalificacion()
        {
            string mensajePrevio = alumno.mostrarCalificacion();

            int calificacion = alumno.getCalificacion();
            Cadena calificacionEnLetras = (Cadena)(numerosEnLetras.valorDe(new Numero(calificacion)));

            string mensaje = string.Format("{0}:{1}", mensajePrevio, calificacionEnLetras);
            return mensaje;
        }

        //Funciones auxiliares

        //Retorna una coleccion Diccionario (diseñada en anteriores practicas) donde guardar un grupo
        //ClaveValor con un numero y su valor en letras, ej (0, CERO).
        //Solo funciona para un rango de 0-10
        private static Diccionario crearNumeroLetra()
        {
            Diccionario numeroYLetras = new Diccionario();
            string[] numerosEnLetras = {"CERO", "UNO", "DOS", "TRES", "CUATRO",
                "CINCO", "SEIS", "SIETE", "OCHO", "NUEVE", "DIEZ"};

            for (int i = 0; i < 11; i++)
            {
                //Se agrega al diccionario los valores construyendose internamente en ClaveValor a partir de Comparables
                numeroYLetras.agregar(new Numero(i), new Cadena(numerosEnLetras[i]));
            }
            return numeroYLetras;
        }


    }
}
