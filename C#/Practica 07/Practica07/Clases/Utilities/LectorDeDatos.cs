using System;

namespace Practica07
{
	public class LectorDeDatos
	{
		static LectorDeDatos instanciaUnica = null;
		private Manejador manejador;
		
		private LectorDeDatos()
		{
			manejador = new NumeroPorTecladoManejador(null);
			manejador = new StringPorTecladoManejador(manejador);
		}
		
		public int numerosPorTeclado(){
			return manejador.numerosPorTeclado();
		}
		
		public string stringPorTeclado(){
			return manejador.stringPorTeclado();
		}
		
		public static LectorDeDatos GetInstance(){
			if(instanciaUnica == null)
				instanciaUnica = new LectorDeDatos();
			return instanciaUnica;
		}
	}
}
