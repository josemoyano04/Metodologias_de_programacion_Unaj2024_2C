using System;

namespace Practica04
{
	public class Diccionario: Coleccionable, IIterable
	{
		//Atributos
		private static int contadorClave = 0;
		private Conjunto elementos = new Conjunto();
		
		
		//Constructor
		public Diccionario(){}

		//Getter
		public Conjunto GetElementos(){
			return this.elementos;
		}
		
		//Metodos
		public void agregar(Comparable clave, Comparable valor){
			
			IIterador iterador = elementos.crearIterador();
			
			while (!iterador.fin()) {
				ClaveValor actual = (ClaveValor)iterador.actual();
				
				if (actual.sosIgual(clave)){
					actual.SetValor(valor);
					break;
				}
				iterador.siguiente();
			}
			ClaveValor nuevoElemento = new ClaveValor(clave, valor);
			elementos.agregar(nuevoElemento);
			
			
		}
		
		public Comparable valorDe(Comparable clave){
			IIterador iterador = elementos.crearIterador();
			
			while (!iterador.fin()) {
				ClaveValor actual = (ClaveValor)iterador.actual();
				
				if (actual.sosIgual(clave)){
					return actual.GetValor();
				}
				
				iterador.siguiente();
			}
			return null;
		}
		
		
		
		//Implementacion de Coleccionable

		public int cuantos(){
			return elementos.cuantos();
		}

		public Comparable minimo(){
			IIterador iterador = elementos.crearIterador();
			ClaveValor min = (ClaveValor)iterador.actual();
			
			iterador.siguiente(); //Evita que se compare el primer elemento de la coneccion en la
			//primer iteracion del bucle
			
			while (!iterador.fin()) {
				ClaveValor actual = (ClaveValor)iterador.actual();
				
				if (actual.GetValor().sosMenor((min.GetValor()))){
					min = actual;
				}
				iterador.siguiente();
			}
			return min;
			
		}

		public Comparable maximo(){
			IIterador iterador = elementos.crearIterador();
			ClaveValor max = (ClaveValor)iterador.actual();
			
			iterador.siguiente(); //Evita que se compare el primer elemento de la coneccion en la
			//primer iteracion del bucle
			
			while (!iterador.fin()) {
				ClaveValor actual = (ClaveValor)iterador.actual();
				
				if (actual.GetValor().sosMayor(max.GetValor())){
					max = actual;
				}
				iterador.siguiente();
			}
			return max;
		}
		
		public void agregar(Comparable valor)
		{
			
			Comparable clave = new Numero(contadorClave);
			this.agregar(clave, valor);
			
			contadorClave++;
		}
		
		public bool contiene(Comparable valor)
		{
			foreach (Comparable cV in elementos.GetElementos()) {
				
				ClaveValor claveValorIterado = (ClaveValor)cV;
				
				if(claveValorIterado.GetValor().sosIgual(valor)){
					return true;
				}
			}
			return false;
			
		}
		
		//Implementacion de IIterable
		public IIterador crearIterador(){
			return new IteradorDiccionario(this);
		}
		
	}
}
