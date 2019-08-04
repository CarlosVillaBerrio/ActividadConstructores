﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstructorCube : MonoBehaviour
{
    
    public int limiteCreaciones = 10; // LIMITE DE ITERACIONES
    int nEnemy, nAlly, pNombre, pEdad; // VARIABLES DEL PROBLEMA
    int zombieColor; // VARIABLE QUE DECIDE EL COLOR DEL ZOMBIE
    public GameObject heroCube; // VARIABLE PARA EL PREFAB DEL HEROE
    string[] nombreAldeano; // NOMBRE DE LA MATRIZ DE NOMBRES
    string aldeanoNombre;
    void Start()
    {
        nEnemy = Random.Range(5, limiteCreaciones); // DECIDE LA CANTIDAD DE ZOMBIES
        nAlly = limiteCreaciones - nEnemy; // CALCULA LAS ITERACIONES FALTANTES
        nAlly = Random.Range(0, nAlly); // SEGUN LAS ITERACIONES QUE FALTAN CREA EL RESTO EN ALDEANOS

        nombreAldeano = new string[20] { "Brayan", "Omaira", "Carlos", "Jorge", "Omar", "David", "Mr Pickles", "Kim Jo Il", "Kim Il Sun", "Hittler", "Satan", "Javier",
        "José", "Blador", "Cesar", "Augusto", "Sara", "Salome", "Ana", "Jairo" };

        Heroe salvacion = new Heroe(heroCube); // CREA AL HEROE EN ESCENA DEBAJO DE LA DIRECTIONAL LIGHT

        for (int i = 0; i < nEnemy; i++) // CICLO QUE CREA UN ZOMBIE POR CADA ITERACION
        {
            zombieColor = Random.Range(0, 3); // DECIDE EL COLOR DEL ZOMBIE INVOCADO
            Zombie muerto = new Zombie(zombieColor); // CONSTRUCTOR QUE CREA AL ZOMBIE
        }

        for (int i = 0; i < nAlly; i++) // CICLO QUE CREA UN ALDEANO POR CADA ITERACION
        {
            pNombre = Random.Range(0, 20); // DECIDE AL AZAR EL NOMBRE DEL ALDEANO
            aldeanoNombre = nombreAldeano[pNombre];
            pEdad = Random.Range(15, 100); // DECIDE AL AZAR LA EDAD DEL ALDEANO

            Aldeano vivo = new Aldeano(aldeanoNombre, pEdad); // CONSTRUCTOR QUE CREA AL ALDEANO
        }
    }

    class Heroe // CONSTRUCTOR PARA EL HEROE
    {
        GameObject cHeroe; // VARIABLE LOCAL

        public Heroe(GameObject heroCube) // METODO DEL CONSTRUCTOR HEROE
        {
            cHeroe = heroCube; // ASOCIA LAS VARIABLES LOCALES CON LAS GLOBALES
            cHeroe.name = "Heroe"; // NOMBRA AL HEROE EN LA JERARQUIA
            cHeroe = GameObject.Instantiate(heroCube, new Vector3(493.40f, 15.36f, 821.33f), Quaternion.identity); // INSTANCIA AL HEROE EN ESCENA
        }
    }

    class Zombie // CONSTRUCTOR PARA ZOMBIE
    {
        Color zColor; // VARIABLES LOCALES PARA LA CLASE ZOMBIE
        string aColor;
        int numColor;

        public Zombie(int zombieColor) // METODO DEL CONSTRUCTOR ZOMBIE
        {
            numColor = zombieColor;
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube); // CREA LA FIGURA SOLICITADA
            Vector3 v = new Vector3(Random.Range(490, 500), 16.55f, Random.Range(815, 825)); // ELIGE UNA POSICION ALEATORIA
            go.transform.position = v; // ASIGNA LA POSICION A UNA VARIABLE
            switch (numColor) // SELECTOR DE COLOR DEPENDIENTE DEL NUMERO
            {
                case 0:
                    zColor = Color.cyan;
                    aColor = "Cyan";
                    break;
                case 1:
                    zColor = Color.green;
                    aColor = "Verde";
                    break;
                case 2:
                    zColor = Color.magenta;
                    aColor = "Magenta";
                    break;
            }

            go.GetComponent<Renderer>().material.color = zColor; // ASIGNA EL COLOR OBTENIDO AL ZOMBIE
            go.AddComponent<Rigidbody>(); // AÑADE CUERPO SOLIDO AL ZOMBIE
            go.GetComponent<Rigidbody>().freezeRotation = true; // CONGELA LA ROTACION PARA EVITAR QUE SE VOLTEE EL CUBO Y TRASPASE EL TERRENO Y CAIGA
            go.name = "Zombie " + aColor; // NOMBRE DEL ZOMBIE EN LA JERARQUIA
            print(DarMensajeZombie(aColor)); // MENSAJE DEL ZOMBIE EN CONSOLA  
        }

        string DarMensajeZombie(string aColor) // METODO QUE DA EL MENSAJE DEL ZOMBIE
        {
            string mensaje;

            mensaje = "Soy un zombie color " + aColor;
            return mensaje;
        }
    }

   
    class Aldeano // CONSTRUCTOR PARA ALDEANO
    {
        string goName; // VARIABLE PARA ASIGNAR EL NOMBRE DADO POR LA MATRIZ
        int goEdad; // VARIABLE PARA ASIGNAR LA EDAD

        public Aldeano(string aldeanoNombre, int pEdad) // METODO DEL CONSTRUCTOR ALDEANO
        {
            goName = aldeanoNombre;
            goEdad = pEdad;

            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube); // CREA LA FIGURA SOLICITADA
            Vector3 v = new Vector3(Random.Range(490, 500), 16.808f, Random.Range(815, 825)); // ELIGE UNA POSICION ALEATORIA
            go.transform.position = v; // ASIGNA LA POSICION A UNA VARIABLE
            go.GetComponent<Renderer>().material.color = Color.yellow; // ASIGNA UN COLOR PARA IDENTIFICAR A LOS ALDEANOS
            go.AddComponent<Rigidbody>(); // AÑADE CUERPO SOLIDO AL ZOMBIE
            go.GetComponent<Rigidbody>().freezeRotation = true; // CONGELA LA ROTACION PARA EVITAR QUE SE VOLTEE EL CUBO Y TRASPASE EL TERRENO Y CAIGA

            go.name = aldeanoNombre; // NOMBRE DEL ALDEANO EN LA JERARQUIA

            print(DarMensajeAldeano(goName, goEdad)); // MENSAJE DEL ALDEANO EN LA CONSOLA
        }

        string DarMensajeAldeano(string goName, int goEdad) // METODO QUE DA EL MENSAJE DEL ALDEANO
        {
            string mensaje; // VARIABLE QUE COMPONE EL CONJUNTO DE MENSAJES

            string mensaje1 = "Hola Soy "; // CONJUNTO DE VARIABLES QUE REPRESENTAN PARTES DEL MENSAJE A MOSTRAR EN CONSOLA
            string mensaje2 = goName;
            string mensaje3 = " y tengo ";
            string mensaje4 = goEdad.ToString();
            string mensaje5 = " años";

            mensaje = mensaje1 + mensaje2 + mensaje3 + mensaje4 + mensaje5;
            return mensaje;
        }
    }
}