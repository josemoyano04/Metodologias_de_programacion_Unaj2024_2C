
using System;

namespace Practica06
{
    public class FabricaDeAlumnosMuyEstudiosos : FabricaDeAlumnos
    {

        public override Comparable crearAleatorio()
        {
            string nombreAl = nombreAleatorio();
            int dniAl = dniAleatorio();
            int legajoAl = legajoAleatorio();
            int promedioAl = promedioAleatorio();

            return new AlumnoMuyEstudioso(nombreAl, dniAl, legajoAl, promedioAl);
        }

        public override Comparable crearPorTeclado()
        {
            Console.WriteLine("---CREAR ALUMNO---");

            //Utilizacion de metodos de FabricaDePersona
            string nombreTecl = nombreTeclado();
            int dniTecl = dniTeclado();
            int legajoTecl = legajoPorTeclado();
            int promedioTecl = promedioPorTeclado();


            return new AlumnoMuyEstudioso(nombreTecl, dniTecl, legajoTecl, promedioTecl);
        }

    }
}
