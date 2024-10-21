
using System;

namespace Practica06
{
    public class FabricaDeAlumnos : FabricaDePersonas
    {
        public override Comparable crearAleatorio()
        {
            string nombreAl = nombreAleatorio();
            int dniAl = dniAleatorio();
            int legajoAl = legajoAleatorio();
            int promedioAl = promedioAleatorio();

            return new Alumno(nombreAl, dniAl, legajoAl, promedioAl);
        }

        public override Comparable crearPorTeclado()
        {
            Console.WriteLine("---CREAR ALUMNO---");

            //Utilizacion de metodos de FabricaDePersona
            string nombreTecl = nombreTeclado();
            int dniTecl = dniTeclado();
            int legajoTecl = legajoPorTeclado();
            int promedioTecl = promedioPorTeclado();

            return new Alumno(nombreTecl, dniTecl, legajoTecl, promedioTecl);
        }

        //Metodos correspondientes faltantes para la creacion de alumnos
        //Aleatorios
        protected int legajoAleatorio()
        {
            return aleatorio.numeroAleatorio(1000);
        }
        protected int promedioAleatorio()
        {
            return aleatorio.numeroAleatorio(11);
        }
        //Por Teclado
        protected int legajoPorTeclado()
        {
            Console.Write("Legajo: ");
            return teclado.numerosPorTeclado();
        }
        protected int promedioPorTeclado()
        {
            Console.Write("Promedio: ");
            int promedioTecl = -1;

            bool promValido = false;
            while (!promValido)
            {
                promedioTecl = teclado.numerosPorTeclado();
                if (promedioTecl < 0 || promedioTecl > 10)
                {
                    Console.WriteLine("El promedio debe estar dentro del rango de 0 a 10, ambos inclusive");
                }
                else
                    promValido = true;
            }
            return promedioTecl;
        }

    }
}
