
using System;

namespace Practica06
{
	/// <summary>
	/// Description of FabricaDeProfesor.
	/// </summary>
	public class FabricaDeProfesor: FabricaDePersonas
	{
		public FabricaDeProfesor(){}
		
		public override Comparable crearAleatorio()
		{
			//Utilizacion de metodos de FabricaDePersona
			string nombreAl = nombreAleatorio();
			int dniAl = dniAleatorio(); 
			
			//Atributos restantes para cracion de Profesor
			int antiguedadAl= aleatorio.numeroAleatorio(25);
			
			return new Profesor(nombreAl, dniAl, antiguedadAl);
		}
		
		public override Comparable crearPorTeclado()
		{
			//Utilizacion de metodos de FabricaDePersona
			string nombreTec = nombreTeclado();
			int dniTec = dniTeclado(); 
			
			//Atributos restantes para cracion de alumno
			Console.Write("Antigueda: ");
			int antiguedadTec = teclado.numerosPorTeclado();
			
			return new Profesor(nombreTec, dniTec, antiguedadTec);
		}
	}
}
