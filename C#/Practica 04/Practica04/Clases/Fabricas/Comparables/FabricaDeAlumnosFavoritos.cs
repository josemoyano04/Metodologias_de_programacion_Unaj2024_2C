
using System;

namespace Practica04
{

	public class FabricaDeAlumnosFavoritos: FabricaDeAlumnos
	{
		public override Comparable crearAleatorio()
		{
			string nombreAl = nombreAleatorio();
			int dniAl = dniAleatorio();
			int legajoAl = aleatorio.numeroAleatorio(1000);
			int promedioAl = aleatorio.numeroAleatorio(11);
			
			return new AlumnoFavorito(nombreAl, dniAl, legajoAl, promedioAl);
		}
		
		public override Comparable crearPorTeclado()
		{
			Console.WriteLine("---CREAR ALUMNO---");
			
			//Utilizacion de metodos de FabricaDePersona
			string nombreTecl = nombreTeclado();
			int dniTecl = dniTeclado(); 
			
			//Atributos restantes para cracion de alumno
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
			
			return new AlumnoFavorito(nombreTecl, dniTecl, legajoTecl, promedioTecl);
		}
	}
}
