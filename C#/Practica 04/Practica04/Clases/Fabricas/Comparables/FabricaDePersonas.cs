
using System;

namespace Practica04
{

    //EJERCICIO 10 OPCIONAL _ AMPLIACION DE JERARQUIA DE FABRICAS
    public abstract class FabricaDePersonas : FabricaDeComparables
    {
        //Metodos correspondientes a la creacion de atributos de persona
        //Aleatorios
        protected string nombreAleatorio()
        {
            return aleatorio.stringAleatorio(5);
        }
        protected int dniAleatorio()
        {
            return aleatorio.numeroAleatorio(1000000);
        }
        //Por teclado
        protected string nombreTeclado()
        {
            Console.Write("Nombre: ");
            return teclado.stringPorTeclado();
        }
        protected int dniTeclado()
        {
            Console.Write("Dni: ");
            return teclado.numerosPorTeclado();
        }

    }
}
