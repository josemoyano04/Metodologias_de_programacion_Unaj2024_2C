using System;
using System.Threading;

namespace Practica06
{
	public class FabricaDeAlumnoCompuesto: FabricaDeComparables
	{
		int opcion;
		
		const int ALUMNO_COMPUESTO_BASICO = 1; //AlumnoProxy
		const int ALUMNO_COMPUESTO_MUY_ESTUDIOSO = 2; //AlumnoMuyEstudisoProxy
		
		public FabricaDeAlumnoCompuesto(int op) { this.opcion = op; }

		public override Comparable crearAleatorio()
		{
			AlumnoCompuesto ac = new AlumnoCompuesto();
			
			switch (opcion) {
				case ALUMNO_COMPUESTO_BASICO:
					for(int i = 0; i < 5; i++){
						ac.agregarHijo((IAlumno)FabricaDeComparables.crearAleatorio(5));
						Thread.Sleep(10);
					}
					break;
					
				case ALUMNO_COMPUESTO_MUY_ESTUDIOSO:
					for(int i = 0; i < 5; i++){
						ac.agregarHijo((IAlumno)FabricaDeComparables.crearAleatorio(6));
						Thread.Sleep(10);
					}
					break;
			}
			
			return ac;
		}

		public override Comparable crearPorTeclado()
		{
			AlumnoCompuesto ac = new AlumnoCompuesto();
			
			switch (opcion) {
				case ALUMNO_COMPUESTO_BASICO:
					for(int i = 0; i < 5; i++){
						ac.agregarHijo((IAlumno)FabricaDeComparables.crearPorTeclado(5));
						Thread.Sleep(1);
					}
					break;
					
				case ALUMNO_COMPUESTO_MUY_ESTUDIOSO:
					for(int i = 0; i < 5; i++){
						ac.agregarHijo((IAlumno)FabricaDeComparables.crearPorTeclado(6));
						Thread.Sleep(1);
					}
					break;
			}
			
			return ac;
		}

		
	}
}
