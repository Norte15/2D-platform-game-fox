using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Programacion orientada a objetos
//Clase >> plantilla >> ejemplo: coche
//---Atributos (variables) >> potencia del coche, num puertas, color, caballos, etc.
//---Funciones/Metodos >> acelerar, frenar, girar, etc.
//OBJETO: Heredar la clase coche, con una serie de atributos y funciones.

public class MiPrimerScript : MonoBehaviour
{
    //GENERAR VARIABLES
    //1.tipo de acceso >> publico o privado >> public o private
    //2.tipo de variable
    //--- int >> numerico, sin decimales, positivos y negativos = 50, 150
    //--- float >> numerico, con decimales, positivos y negativos = 50.1f, 2.123f
    //--- string >> texto, caracteres alfanumericos >> hola, 109, #
    //--- bool >> 0 o 1, true o false
    //--- componente >> se llama igual que el componente en unity, por ejemplo: transform
    //3.nombre >> potenciaDeSalto
    //tipoDeAcceso tipoDeVariable nombreVariable

    //OPERADORES
    // =
    // +
    // -
    // *
    // /


    //VARIABLES DE TIPO VECTOR
    //Vector2
    //a(1,0) >> x,y
    //Vector3
    //a(1,2,0( >> x,y,z
    //
    //SUMA
    //a(1,0,2)
    //b(5,1,3)
    //a+b(6,1,5)

    //numero1 = numero1 + numero2;
    //numero1 += numero2;
    //numero1++;

    //FUNCIONES
    //Nos permiten ejecutar varias lineas de codigo (llamamiento)
    //
    //DECLARAR FUNCIONES
    //1.Tipos de acceso >> public o private
    //2.tipos de funcion
    //----los mismos que en las variables, pero se añade el tipo VOID
    //----tipo void: no retorna nada, es una funcion "vacia".
    //3.Nombre >> dañoAPersonaje
    //
    //Ejemplo:
    //variable vida, funcion restar vida.
    //funcion void (vacia): variable vida - daño.
    //funcion int : variable vida - funcion int.
    //4. () *pueden estar vacios o pueden llevar variables dentro
    //5.{} *aqui vamos a meter las intrucciones de codigo
    //
    //Ejemplo declaracion:
    //public void QuitarVidaAPersonaje ()
    //{
    //instruccion1;
    //instruccion2;
    //}
    //
    //COMO LLAMAR A FUNCIONES
    //Nombre de la funcion();
    //Ejemplo: QuitarVidaAPersonaje();
    //
    //CONDICIONALES
    //IF >> en funcion de una condicion, pasara una cosa si se cumple o pasara otra si no se cumple.
    //
    //Estructura del condicional IF:
    //1. if
    //2. (condicion)
    //--como hacer condiciones:
    //== igual a
    //> mayor que
    //< menor que
    //>= mayor o igual que
    //<= menor o igual que
    //Ejemplo: if (numero1 >= numero2)
    //3. {}
    //Dentro de las llaves pondremos las instrucciones a ejecutar SI la condicion se cumple.
    //4a. else {}
    //dentro de estas llaves vamos a poner las instrucciones a ejecutar si no se cumple la condicion
    //---Ejemplo: if (numero1 >= numero2) {instrucciones} else {instrucciones}
    //4b. else if ( numero1 == 0 ) {instrucciones}
    //numero esta entre -5 y -1
    //Operadores para añadir mas condiciones
    //----|| >> que se cumpla una condicon u otra
    //----&& >> obliga a que se cumplan todas las condiciones
    //Ejemplo: if (numero1 > -50 && numero1 <-1)
    //Ejemplo: if (numero1 == 1 || numero1 == 2)

    public int vida = 100;
    public bool interruptor = true;
    public string nombreJugador = "Hola mundo";
    public Transform posicionJugador;
    public Vector3 nuevaPosicion;



    // Start is called before the first frame update
    void Start()
    {
        vida = vida + 50;
        print(vida);

        print(interruptor);
        interruptor = false;
        print(interruptor);

        print(nombreJugador);

        posicionJugador.position = posicionJugador.position + nuevaPosicion;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
