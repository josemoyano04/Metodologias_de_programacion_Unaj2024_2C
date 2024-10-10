
using System;

namespace Practica03
{
	public class FabricaDeAlumnos : FabricaDeComparables
	{
		public override Comparable crearAleatorio()
		{
			string nombreAl = aleatorio.stringAleatorio(5);
			int dniAl = aleatorio.numeroAleatorio(1000000);
			int legajoAl = aleatorio.numeroAleatorio(1000);
			int promedioAl = aleatorio.numeroAleatorio(11);
			
			return new Alumno(nombreAl, dniAl, legajoAl, promedioAl);
		}
		
		public override Comparable crearPorTeclado()
		{
			Console.WriteLine("---CREAR ALUMNO---");
			Console.Write("Nombre: ");
			string nombreTecl = teclado.stringPorTeclado();
			Console.Write("Dni: ");
			int dniTecl = teclado.numerosPorTeclado();
			Console.Write("Legajo: ");
			int legajoTecl = teclado.numerosPorTeclado();
			Console.Write("Promedio: ");
			int promedioTecl = -1;
			
			bool promValido = false;
			while(!promValido){
				promedioTecl = teclado.numerosPorTeclado();
				if (promedioTecl < 0 || promedioTecl > 10)
				{
					Console.WriteLine("El promedio debe ser mayor a 0 y menor que 10");
				}
				else
					promValido = true;
			}
			
			return new Alumno(nombreTecl, dniTecl, legajoTecl, promedioTecl);
		}
	}
}
