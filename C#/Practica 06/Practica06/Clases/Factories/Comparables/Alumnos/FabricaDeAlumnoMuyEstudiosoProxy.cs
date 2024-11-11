using System;

namespace Practica06
{
	public class FabricaDeAlumnoMuyEstudiosoProxy: FabricaDeAlumnos
	{
		public override Comparable crearAleatorio()
		{
			string nombreAl = this.nombreAleatorio();
			int dniAl = dniAleatorio();
            int legajoAl = legajoAleatorio();
            int promedioAl = promedioAleatorio();

            AlumnoMuyEstudiosoProxy a = new AlumnoMuyEstudiosoProxy(nombreAl, dniAl, legajoAl, promedioAl);
            
            return a;
			
			
		}

		public override Comparable crearPorTeclado()
		{
			Console.WriteLine("---CREAR ALUMNO(Proxy)---");

            string nombreTecl = nombreTeclado();
            int dniTecl = dniTeclado();
            int legajoTecl = legajoPorTeclado();
            int promedioTecl = promedioPorTeclado();

            AlumnoMuyEstudiosoProxy a = new AlumnoMuyEstudiosoProxy(nombreTecl, dniTecl, legajoTecl, promedioTecl);
            
            return a;
		}
	}
}
