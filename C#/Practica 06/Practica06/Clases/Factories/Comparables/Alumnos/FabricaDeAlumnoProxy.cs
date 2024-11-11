using System;

namespace Practica06
{
	public class FabricaDeAlumnoProxy: FabricaDeAlumnos
	{
		public override Comparable crearAleatorio()
		{
			string nombreAl = this.nombreAleatorio();
			int dniAl = dniAleatorio();
            int legajoAl = legajoAleatorio();
            int promedioAl = promedioAleatorio();

            AlumnoProxy a = new AlumnoProxy(nombreAl, dniAl, legajoAl, promedioAl);
            a.setCalificacion(promedioAl);
            return a;
			
			
		}

		public override Comparable crearPorTeclado()
		{
			Console.WriteLine("---CREAR ALUMNO(Proxy)---");

            string nombreTecl = nombreTeclado();
            int dniTecl = dniTeclado();
            int legajoTecl = legajoPorTeclado();
            int promedioTecl = promedioPorTeclado();

            AlumnoProxy a = new AlumnoProxy(nombreTecl, dniTecl, legajoTecl, promedioTecl);
            a.setCalificacion(promedioTecl);
            return a;
		}
	}
}
