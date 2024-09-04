class IColeccionable:
    pass
class IComparable:
    pass
def obtener_nombres_subclases(a):
    pass


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
    
    
    # Impresion y seleccion de clases con consulta posible 
    subclase_valida = False
    intentos = 1
    while not subclase_valida and intentos <= 3:
        print("Ingrese el tipo de IComparable que desea consultar: ")
        for subclase in obtener_nombres_subclases(IComparable):
            print(subclase)

        subclase_input = input("seleccion: ").capitalize()

        if subclase_input in obtener_nombres_subclases(IComparable):
            subclase_valida = True
        
        intentos += 1
    
    if intentos == 3:
        subclase_input = None
        
    #Solicitud de valor consultado e impresion de datos
    
    if subclase_input != None:
        valor_valido = False
        while not valor_valido:
            try:   
                valor_consultado = int(
                    input(
                        f"\nIngrese el valor que desea consultar si se encuentra en el coleccionable: "
                    )
                )
                if type(valor_consultado) != int:
                    valor_valido = False
                    continue
                valor_valido = True

            except ValueError:
                    valor_valido = False
    else:
        print("Contine --: No consultado")
    
    #Impresion de primeros items
    print(
        f"""Cantidad de elementos: {coleccionable.cuantos()}
Elemento minimo: {coleccionable.minimo().get_valor_comparado()}
Elemento maximo: {coleccionable.maximo().get_valor_comparado()}\n"""
    )
# Contiene {valor_consultado}: {coleccionable.contiene((globals()[subclase_input]).crear_instancia_comparable(Dni = valor_consultado))}"""
