using System;

namespace Practica07
{
	public class GeneradorDeDatosAleatorios
	{
		static GeneradorDeDatosAleatorios instanciaUnica = null;
		Manejador manejador;
		
		private GeneradorDeDatosAleatorios()
		{
			//Cadena de responsabilidades
			manejador = new NumeroAleatorioManejador(null);
			manejador = new StringAleatorioManejador(manejador);
		}
		
		public int numeroAleatorio(int max){
			return manejador.numeroAleatorio(max);
		}
		
		public string stringAleatorio(int cant){
			return manejador.stringAleatorio(cant);
		}
		
		public static GeneradorDeDatosAleatorios GetInstance(){
			if(instanciaUnica == null)
				instanciaUnica = new GeneradorDeDatosAleatorios();
			return instanciaUnica;
				
		}
	}
}
