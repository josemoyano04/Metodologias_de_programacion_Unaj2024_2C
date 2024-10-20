using System;

namespace Practica05
{
	public class GeneradorDeDatosAleatorios
	{
		Random r = new Random();
		
		public int numeroAleatorio(int max){
			return r.Next(0, max);
		}
		
		public string stringAleatorio(int cant){
			
			string strAleatorio = "";
			
			int[] RANGO_MINUSCULAS = {97, 123};
			int[] RANGO_MAYUSCULAS = {65, 91};
			int[] RANGO_NUMEROS = {48, 58};
			
			int[][] RANGOS = {RANGO_MINUSCULAS, RANGO_MAYUSCULAS, RANGO_NUMEROS};
			
			for(int i = 0; i < cant; i++){
				int rangoAl = r.Next(0, 3);
				char charAleatorio = (char)r.Next(RANGOS[rangoAl][0], RANGOS[rangoAl][1]);
				strAleatorio = strAleatorio + charAleatorio;
			}
			
			return strAleatorio;
		}
	}
}
