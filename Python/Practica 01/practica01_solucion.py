from abc import ABCMeta, abstractmethod
from random import randint


# interfaces
# Ejercicio 1: implementar una interfaz "Comparable"
class IComparable(metaclass=ABCMeta):
    
    @abstractmethod
    def get_valor_comparado():
        pass
    
    @abstractmethod
    def sosIgual(Self, comparable):
        pass

    @abstractmethod
    def sosMenor(self, comparable):
        pass

    @abstractmethod
    def sosMayor(self, comparable):
        pass

        
    @abstractmethod
    def crear_instancia_comparable(*valor_comparable):
        pass
# Ejercicio 3: Implementar la interface Coleccionable
class IColeccionable(metaclass=ABCMeta):

    @abstractmethod
    def cuantos():
        pass

    @abstractmethod
    def minimo():
        pass

    @abstractmethod
    def maximo():
        pass

    @abstractmethod
    def agregar(Comparable):
        pass

    @abstractmethod
    def contiene(Comparable):
        pass

# Clases
# Ejercicio 2: Implemente la clase Numero
class Numero(IComparable):

    def __init__(self, v):
        self.__valor = v

    def __eq__(self, objetoNumero: "Numero") -> bool:
        # Metodo implementado para evitar errores no esperados al momento de comparar 2 instancias de Numero.
        # Esta funcion permite que al momento de comparar 2 objetos que guarden el mismo valor, pero que se instancien
        # en distintas variables, ésta retorne True si sus valores son iguales a pesar de que tecnicamente sean objetos distintos.
        if isinstance(objetoNumero, Numero):
            return self.get_valor() == objetoNumero.get_valor()

    def get_valor(self):
        return self.__valor

    # Definicion de metodos abstractos de Comparable
    def get_valor_comparado(self):
        return self.get_valor()
    
    def sosIgual(self, comparable: "Numero"):
        if not isinstance(comparable, Numero):
            raise ValueError(
                "La funcion solo recibe instancias del mismo tipo a la instancia que la invoque"
            )

        return True if self.get_valor_comparado() == comparable.get_valor_comparado() else False

    def sosMenor(self, comparable: "Numero"):
        if not isinstance(comparable, Numero):
            raise ValueError(
                "La funcion solo recibe instancias del mismo tipo a la instancia que la invoque"
            )

        return True if self.get_valor_comparado() < comparable.get_valor_comparado() else False

    def sosMayor(self, comparable: "Numero"):
        if not isinstance(comparable, Numero):
            raise ValueError(
                "La funcion solo recibe instancias del mismo tipo a la instancia que la invoque"
            )

        return True if self.get_valor_comparado() > comparable.get_valor_comparado() else False

    @staticmethod
    def crear_instancia_comparable(num: int):
        return Numero(num)

# Ejercicio 4: Implemente  las  clases  Pila  y  Cola
class Pila(IColeccionable):
    def __init__(self, *elementos: IComparable):

        for elemento in elementos:
            if not isinstance(elemento, IComparable):
                raise ValueError(
                    "El constructor de Pila solo recibe instancias de IComparable"
                )
        self.__elementos = list(elementos)

    def get_elementos(self):
        return self.__elementos

    # Implemetacion de metodos abstractos de IColeccionable

    def cuantos(self):
        return len(self.get_elementos())

    def minimo(self):
        valor_min = self.get_elementos()[0]

        for valor in self.__elementos:
            if valor.sosMenor(valor_min):
                valor_min = valor

        return valor_min

    def maximo(self):
        valor_max = self.get_elementos()[0]

        for valor in self.get_elementos():
            if valor.sosMayor(valor_max):
                valor_max = valor

        return valor_max

    def agregar(self, Comparable: IComparable):
        if not isinstance(Comparable, IComparable):
            raise ValueError("El metodo debe recibir un objeto IComparable")

        self.__elementos.append(Comparable)

    def contiene(self, Comparable: IComparable):
        
        if not isinstance(Comparable, IComparable):
            raise ValueError("El metodo debe recibir un objeto IComparable")
        
               
        return True if Comparable in self.get_elementos() else False



    def quitar(self):
        try:
            self.__elementos.pop()
        except IndexError:
            pass


class Cola(IColeccionable):
    def __init__(self, *elementos: IComparable):

        for elemento in elementos:

            if not isinstance(elemento, IComparable):
                raise ValueError(
                    "El constructor de Cola solo recibe instancias de IComparable"
                )

        self.__elementos = list(elementos)

    def get_elementos(self):
        return self.__elementos

    # Definicion de metodos abstractos de IColeccionables

    def cuantos(self):
        return len(self.get_elementos())

    def minimo(self):
        valor_min = self.get_elementos()[0]

        for valor in self.__elementos:
            if valor.sosMenor(valor_min):
                valor_min = valor

        return valor_min

    def maximo(self):
        valor_max = self.get_elementos()[0]

        for valor in self.__elementos:
            if valor.sosMayor(valor_max):
                valor_max = valor

        return valor_max

    def contiene(self, Comparable: IComparable):
        if not isinstance(Comparable, IComparable):
            raise ValueError("El metodo debe recibir un objeto IComparable")

        return True if Comparable in self.get_elementos() else False

    def agregar(self, Comparable: IComparable):  # Agrega al final de la lista

        if not isinstance(Comparable, IComparable):
            raise ValueError("El metodo debe recibir un objeto IComparable")

        self.__elementos.append(Comparable)

    def quitar(self):  # Quita el primer elemento de la lista
        try:
            self.__elementos.pop(0)
        except IndexError:
            pass

# ejercicio 8: Cree la clase ColeccionMultiple
class ColleccionMultiple(IColeccionable):
    def __init__(self, p: Pila, c: Cola):

        self.__pila = p
        self.__cola = c

    def get_pila(self):
        return self.__pila

    def get_cola(self):
        return self.__cola

    # Implementacion de metodos abstractos de IColeccionable:

    def cuantos(self):
        cant_total = self.__pila.cuantos() + self.__cola.cuantos()
        return cant_total

    def minimo(self):
        min_pila = self.__pila.minimo()
        min_cola = self.__cola.minimo()

        min_absoluto = min_pila if min_pila.get_valor_comparado() < min_cola.get_valor_comparado() else min_cola
        
        return min_absoluto

    def maximo(self):
        max_pila = self.__pila.maximo()
        max_cola = self.__cola.maximo()

        max_absoluto = max_pila if max_pila.get_valor_comparado() > max_cola.get_valor_comparado() else max_cola
        
        return max_absoluto

    def agregar():
        pass

    def contiene(self, comparable: IComparable):
        if not isinstance(comparable, IComparable):
            raise ValueError("El metodo debe recibir un objeto IComparable")

        return (
            True
            if self.__pila.contiene(comparable) or self.__cola.contiene(comparable)
            else False
        )


# Ejercicio 11: Implemente la clase Persona
class Persona(IComparable):
    def __init__(self, nombre: str, dni: int):
        self.__nombre = nombre 
        self.__dni = dni

    def __eq__(self, objetoPersona: "Persona") -> bool:
        if isinstance(objetoPersona, Persona):
            
            # Si 2 instancias de Persona tienen el mismo Dni, son la misma sin importar el nombre
            return self.get_dni() == objetoPersona.get_dni()
                

    # Getters
    def get_nombre(self):
        return self.__nombre

    def get_dni(self):
        return self.__dni

    def get_valor(self):
        return self.get_dni()
    # Implementacion de metodos abstractos de IComparable
    def get_valor_comparado(self):
        return self.get_dni()
    
    def sosIgual(self, comparable: IComparable):
        """
        Comparación a travez del Dni de las instancias de Persona
        """
        if not isinstance(comparable, Persona):
            raise ValueError(
                "La funcion solo recibe instancias del mismo tipo a la instancia que la invoque"
            )

        else:
            return True if self.get_valor_comparado() == comparable.get_valor_comparado() else False

    def sosMenor(self, comparable):
        """
        Comparación a travez del Dni de las instancias de Persona
        """
        if not isinstance(comparable, Persona):
            raise ValueError(
                "La funcion solo recibe instancias del mismo tipo a la instancia que la invoque"
            )
        else:
            return True if self.get_valor_comparado() < comparable.get_valor_comparado() else False

    def sosMayor(self, comparable):
        """
        Comparación a travez del Dni de las instancias de Persona
        """
        if not isinstance(comparable, Persona):
            raise ValueError(
                "La funcion solo recibe instancias del mismo tipo a la instancia que la invoque"
            )
        else:
            return True if self.get_valor_comparado() > comparable.get_valor_comparado() else False

    @staticmethod
    def crear_instancia_comparable(Dni: int):
        return Persona(nombre = None, dni = Dni)
# Funciones
# Ejercicio 5: Implemente  una  función  llenar...
def llenar(coleccionable: IColeccionable):

    CANT_AGREGADA = 20
    RANGO_NUMEROS_RANDOM = (-50, 50)

    if not isinstance(coleccionable, IColeccionable):
        raise ValueError("La funcion llenar solo recibe instancias de IColeccionable")

    for i in range(0, CANT_AGREGADA):
        random = randint(RANGO_NUMEROS_RANDOM[0], RANGO_NUMEROS_RANDOM[1])
        coleccionable.agregar(Numero(random))


# Ejercico 11: Implemente una funcion llenarPersonas...
def llenar_personas(coleccionable: IColeccionable):

    def generar_persona_random():
        PREFIJO_NOMBRE_RANDOM = "PersonaRandom"
        RANGO_DNI = (
            1000000,
            70000000,
        )  # 1Millon a 70millones → Rango aproximado de Nros de Dni en Argentina

        dni_random = randint(RANGO_DNI[0], RANGO_DNI[1])
        nombre_random = PREFIJO_NOMBRE_RANDOM + str(i)
        persona = Persona(nombre_random, dni_random)

        return persona

    CANT_AGREGADA = 20
    for i in range(0, CANT_AGREGADA):
        coleccionable.agregar(generar_persona_random())


# Ejercicio 6: Implemente  una  función  informar...
def informar(coleccionable: IColeccionable):
    """
    La función `informar` imprime en pantalla los datos del coleccionable que se le pasa por parámetro:
        - La cantidad de elementos del coleccionable.
        - El elemento de valor mínimo.
        - El elemento de valor máximo.
        - Un booleano indicando si un elemento consultado se encuentra dentro del coleccionable.

    - Si se pasa por parámetro un objeto no instanciado de `IColeccionable`, la función lanza una excepción de tipo `ValueError`.

    - Para imprimir el último ítem, primero se solicita el tipo de `Comparable` que se desea verificar su estadía dentro de la colección:
        - Si el `Comparable` ingresado por consola no es un tipo de dato existente, se solicita otro.
        - Si el usuario ingresa en 3 intentos un `Comparable` no existente, la función anula la solicitud de un tipo de dato e imprime un 
        mensaje indicando que no se solicitó consultar un dato.
    """
    
    #Verificacion tipo de dato del argumento ingresado
    if not isinstance(coleccionable, IColeccionable):
        raise ValueError(
            "La funcion informar solo recibe instancias de IColeccionable por parametro"
        )
    
    # Impresion de los tipos de clases posibles
    subclase_valida = False
    while not subclase_valida:
        print("Ingrese el tipo de IComparable que desea consultar: ")
        for subclase in obtener_nombres_subclases(IComparable):
            print(subclase)

        subclase_input = input("seleccion: ").capitalize()

        if subclase_input in obtener_nombres_subclases(IComparable):
            subclase_valida = True

        
    #Solicitud de valor consultado e impresion de datos
    valor_invalido = True
    while valor_invalido:
        try:   
            valor_consultado = int(
                input(
                    "\nIngrese el valor que desea consultar si se encuentra en el coleccionable: "
                )
            )
            if type(valor_consultado) != int:
                valor_invalido = True
                continue
            valor_invalido = False

        except ValueError:
            valor_invalido = True

    print(
        f"""Cantidad de elementos: {coleccionable.cuantos()}
Elemento minimo: {coleccionable.minimo().get_valor_comparado()}
Elemento maximo: {coleccionable.maximo().get_valor_comparado()}
Contiene {valor_consultado}: {coleccionable.contiene((globals()[subclase_input]).crear_instancia_comparable(Dni = valor_consultado))}"""
    )


# funciones auxiliares
def obtener_nombres_subclases(clase: type):
    subclases_objetos = clase.__subclasses__()
    subclases_nombres = list()
    
    for subclase in subclases_objetos:
        subclases_nombres.append(subclase.__name__)
        
    for subclase in subclases_objetos:
        subclases_objetos.extend(obtener_nombres_subclases(subclase))
    
    return subclases_nombres


# Ejercicio 7: Implemente  un  módulo  main  que  cree  una  Pila  y  una  Cola...
# Ejercicio 9: Modifique el módulo main para crear una ColeccionMultiple e informe con esta colección
def main():

    pila, cola = Pila(), Cola()
    coleccion_multiple = ColleccionMultiple(p=pila, c=cola)
    
    llenar_personas(pila)
    llenar_personas(cola)

    print(f"\n*************** Informacion de Pila ***************")
    informar(pila)
    print(f"\n***************************************************")
    
    print(f"\n*************** Informacion de Cola ***************")
    informar(cola)
    print(f"\n***************************************************")

    print(f"\n********** Informacion de Coleccion Multiple **********")
    informar(coleccion_multiple)
    print(f"\n***************************************************")


# Ejercicio 10... Respuesta: Note que las funcion Informar no estaba tan optimizada para realizar
#       la tarea de mostrar datos de una instancia de IColeccionable, sino que estaba pensada
#       para las instancias de Pila y Cola, lo cual era un error grave que no habia notado.
#       Continue con la refactorizacion de dicha funcion para hacer correctamente su tarea
#       y volverla mas general, para que cualquier clase que herede de IColeccionable, sea
#       capaz de llamarla

# Prueba
EJECUTAR_PRUEBA = True
if __name__ == "__main__" and EJECUTAR_PRUEBA:
    main()



print(obtener_nombres_subclases(IColeccionable))
