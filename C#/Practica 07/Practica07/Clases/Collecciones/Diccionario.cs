using System;

namespace Practica07
{
	public class Diccionario: Coleccionable, IIterable, Ordenable
	{
		//Atributos
		private static int contadorClave = 0;
		private Conjunto elementos = new Conjunto();
		
		private OrdenEnAula1 ordenInicio;
		private OrdenEnAula2 ordenLlegaAlumno;
		private OrdenEnAula1 ordenAulaLlena;
		
		//Constructor
		public Diccionario(){}

		//Getter
		public Conjunto GetElementos(){
			return this.elementos;
		}
		
		//Metodos
		public void agregar(Comparable clave, Comparable valor){
			
			ClaveValor claveValor = new ClaveValor(clave, valor);
			
			if (cuantos() == 0 && ordenInicio != null && ordenLlegaAlumno != null) {
				elementos.agregar(claveValor); //No requiere verificacion de contencion ya que es el primer elemento
				
				//Ejecucion de ordenes
				ordenInicio.ejecutar();
				ordenLlegaAlumno.ejecutar(valor); //Guarda el valor en el aula, si no es un AlumnoAdapter o Student produce errores
			}
			
			if (cuantos() >= 1 && cuantos() < 41){ //Como existen elementos, requiere que se verifique que las claves no se repitan
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
				ordenLlegaAlumno.ejecutar(valor); //Requiere que un AlumnoAdapter o Student se envie en el parametro valor. NO ES UNA BUENA 
										//SOLUCION PERO ES TEMPORAL Y FUNCIONA, SI ES NECESARIO MODIFICARIA LA COLECCION COMPLETA 
										//PARA SU CORRECTO FUNCIONAMIENTO
			}
			
			if (cuantos() == 40){
				ordenAulaLlena.ejecutar();
			}
		}
		
		//Metodo auxiliar no solicitado; utiliza polimorfismo y un nuevo parametro booleano para forzar el agregado de un elemento a la coleccion
		//este metodo no interfiere con la implementacion de el patron Command
		public void agregar(Comparable clave, Comparable valor, bool forzarAgregado){
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
		
		//Implementacion de ordenable
		public void setOrdenInicio(OrdenEnAula1 orden)
		{
			ordenInicio = orden;
		}
		public void setOrdenLlegaAlumno(OrdenEnAula2 orden)
		{
			ordenLlegaAlumno = orden;
		}
		public void setOrdenAulaLlena(OrdenEnAula1 orden)
		{
			ordenAulaLlena = orden;
		}
	}
}
