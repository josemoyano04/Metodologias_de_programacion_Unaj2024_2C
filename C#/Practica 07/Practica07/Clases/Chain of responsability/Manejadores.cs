using System;
using System.IO;

namespace Practica07
{
	public abstract class Manejador
	{
		protected Manejador sucesor = null;
		protected Random r = new Random();
		
		
		public Manejador(Manejador sucesor)
		{
			this.sucesor = sucesor;
		}
		
		virtual public int numerosPorTeclado(){
			if (sucesor != null)
				return sucesor.numerosPorTeclado();
			return -1; //A fines de evitar errores;
		}
		virtual public string stringPorTeclado(){
			if(sucesor != null)
				return sucesor.stringPorTeclado();
			return null; //A fines de evitar errores;
		}
		virtual public int numeroAleatorio(int max){
			if(sucesor != null)
				return sucesor.numeroAleatorio(max);
			return -1; //A fines de evitar errores;
		}
		virtual public string stringAleatorio(int cant){
			if(sucesor != null)
				return sucesor.stringAleatorio(cant);
			return null; //A fines de evitar errores;
			
		}
		virtual public double numeroDesdeArchivo(double max,  StreamReader lectorArchivos){
			if(sucesor != null)
				return sucesor.numeroDesdeArchivo(max, lectorArchivos);
			return -1.0;
		}
		virtual public string stringDesdeArchivo(int cant,  StreamReader lectorArchivos){
			if(sucesor != null)
				return sucesor.stringDesdeArchivo(cant, lectorArchivos);
			return null;
		}
	}
		
	public class StringPorTecladoManejador: Manejador{
		
		public StringPorTecladoManejador(Manejador sucesor): base(sucesor)
		{
			this.sucesor = sucesor;
		}
		
		public override string stringPorTeclado()
		{
			string s = Console.ReadLine();
			return s;
		}
	}
	
	public class NumeroPorTecladoManejador: Manejador{
		
		public NumeroPorTecladoManejador(Manejador sucesor): base(sucesor)
		{
			this.sucesor = sucesor;
		}
		
		public override int numerosPorTeclado(){
			int n = -1;
			
			bool valido = false;
			while (!valido) {
				try {
					n = int.Parse(Console.ReadLine());
					valido = true;
				} catch (FormatException) {
					Console.WriteLine("Error. Ingrese un número");
				}
			}
			
			return n;
		}
		
	}
	
	public class NumeroAleatorioManejador: Manejador{
		public NumeroAleatorioManejador(Manejador sucesor): base(sucesor)
		{
			this.sucesor = sucesor;
		}
		
		public override int numeroAleatorio(int max)
		{
			return r.Next(0, max);
		}
	}

	public class StringAleatorioManejador: Manejador{
		public StringAleatorioManejador(Manejador sucesor): base(sucesor)
		{
			this.sucesor = sucesor;
		}
		
		public override string stringAleatorio(int cant)
		{
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

	public class NumeroDesdeArchivoManejador: Manejador{
		
		public NumeroDesdeArchivoManejador(Manejador sucesor): base(sucesor)
		{
			this.sucesor = sucesor;
		}
		
		public override double numeroDesdeArchivo(double max, StreamReader lectorArchivos)
		{
			string linea = lectorArchivos.ReadLine();
			return Double.Parse(linea.Substring(0, linea.IndexOf('\t'))) * max;
		}
	}

	public class StringDesdeArchivoManejador: Manejador {
		
		public StringDesdeArchivoManejador(Manejador sucesor): base(sucesor)
		{
			this.sucesor = sucesor;
		}
		
		public override string stringDesdeArchivo(int cant, StreamReader lectorArchivos)
		{
			string linea = lectorArchivos.ReadLine();
			linea = linea.Substring(linea.IndexOf('\t')+1);
			cant = Math.Min(cant, linea.Length);
			return linea.Substring(0, cant);
		}
	}
}
