# -*- coding: utf-8 -*-

"""
 Ejemplo del uso de interfaces
 
 Este ejemplo corresponde al video de interfaces de la aprimer clase de la materia Metodología de Programación I
 
""" 

from abc import ABCMeta, abstractmethod

# Actividad 1. Implementar las interfaces Negocio, Cliente y Proveedor
	
class Negocio (metaclass = ABCMeta):
    @abstractmethod
    def atenderCliente(self, c):
        pass
    
    @abstractmethod
    def abstacerStock(self):
        pass
    
    @abstractmethod
    def getNombre(self):
        pass

class Cliente (metaclass = ABCMeta):
    @abstractmethod
    def vender(self):
        pass
    
    @abstractmethod
    def comprar(self):
        pass
    
    @abstractmethod
    def getNombre(self):
        pass
	
class Proveedor (metaclass = ABCMeta):
    @abstractmethod
    def negociar(self, n):
        pass
	
# Actividad 2. Implementar una clae Ferretería que implemente la interface Negocio
	
class Ferreteria (Negocio):
    def __init__(self):
        self.__proveedor = Almacen()
		
    def atenderCliente(self, c):
        print("Atendiendo al cliente " + c.getNombre())
		
    def abstacerStock(self):
        self.__proveedor.negociar(self)
        print("El stock fue abastecido")
		
    def getNombre(self):
        return "La solución a todo"
	
# Actividad 3. Implemenar una clse Alimentos que implemente la interface Negocio
	
class Alimento (Negocio):

    def __init__(self):
        self.__proveedor = MercadoCentral()
		
    def abstacerStock(self):
        self.__proveedor.negociar(self)
        print("El stock fue abastecido")
	
# Actividad 4. Implemente tres subclases de Alimneto: Verduleria, Carniceria y Almacen
	
class Verduleria (Alimento):
    def atenderCliente(self, c):
        print("Vendiendo lechuga y tomate al cliente " + c.getNombre())

    def getNombre(self):
        return "La remolacha"
	
class Carniceria (Alimento):
    def atenderCliente(self, c):
        print("Vendiendo carne al cliente " + c.getNombre())

    def getNombre(self):
        return "La vaca loca";	
	
class Almacen (Alimento, Proveedor):
    def atenderCliente(self, c):
        print("Vendiendo leche y yerba al cliente " + c.getNombre())

    def negociar(self, n):
        print ("Abasteciendo el stock de " + n.getNombre())
		
    def getNombre(self):
        return "Try'n'save"

class MercadoCentral (Proveedor):
    def negociar(self, n):
        print("Negociando con " + n.getNombre())

# Actividad 5. Implemente la clase Resto que implemente las interfaces Negocio y Cliente
	
class Resto (Negocio, Cliente):
		
    def __init__(self, p, n):
        self.__negocio = n
        self.__proveedor = p
		
    def atenderCliente(self, c):
        print("Atendiendo al cliente " + c.getNombre())

    def abstacerStock(self):
        self.__proveedor.negociar(self)
        print("La cocina está llena para aeguir preparando comida")
		
    def vender(self):
        self.__negocio.atenderCliente(self)
        print("Vendiendo dólares en mi banco")
		
    def comprar(self):
        self.__negocio.atenderCliente(self)
        print("Comprando dólares en mi banco")
		
    def getNombre(self):
        return "El Bar de Moe"
	
# Actividad 6. Implemente la calase Banco que implemente la interface Negocio

class Banco (Negocio):

    def atenderCliente(self, c):
        print("Haciendo operaciones bancarias con el cliente " + c.getNombre())

    def abstacerStock(self):
        print("No tengo proveedor, me abastesco de mis propios clientes")
		
    def getNombre(self):
        return "El banco que te banca"
	
# Actividad 7 . Implemetne la interface Proveedor en la clase Almacen
# (la implementación está más ariba) 
	
# Clase auxiliar Persona
class Persona (Cliente):
    
    def __init__(self, n):
        self.__negocio = n

    def comprar(self):
        print("Comprando en un hermoso día")
        self.__negocio.atenderCliente(self)

    def vender(self):
        print("Vendiendo en un hermoso día")
        self.__negocio.atenderCliente(self)
		
    def getNombre(self):
        return "Fulano De Tal"

# Actividad 8. Realice un módulo main para testear el correcto funcionamiento de todo lo implemtado
	
def main():
    # Probando Persona como Cliente y Ferretería como Negocio
    print("*** Probando Persona como Cliente y Ferretería como Negocio ***")
    per1 = Persona(Ferreteria())
    per1.comprar()
    per1.vender()
    print("**********************************************************\n\n")
			
    # Probando Persona como Cliente y Carnicería como Negocio
    print("*** Probando Persona como Cliente y Carnicería como Negocio ***")
    per2 = Persona(Carniceria())
    per2.comprar()
    per2.vender()
    print("**********************************************************\n\n")
			
    resto = Resto(Almacen(), Banco())
			
    # Probando Persona como Cliente y Resto como Negocio
    print("*** Probando Persona como Cliente y Resto como Negocio ***")
    per3 = Persona(resto)
    per3.comprar()
    per3.vender()
    print("**********************************************************\n\n")
			
    # Probando Resto como Cliente y Banco como Negocio
    print("*** Probando Resto como Cliente y Banco como Negocio ***")
    resto.comprar()
    resto.vender()
    print("**********************************************************\n\n")
			
    # Probando Resto como Negocio y Almacen como Proveedor
    print("*** Probando Resto como Negocio y Almacen como Proveedor ***")
    resto.abstacerStock()
    print("**********************************************************\n\n")
					
    print("El programa finalizó correctamente.\n")
    
if __name__ == "__main__":
    main()    