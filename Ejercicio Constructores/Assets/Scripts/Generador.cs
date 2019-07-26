using UnityEngine;
using System.Collections;
public class Generador : MonoBehaviour
{

    int zombieS, aldeanoS;
    int limite = 30;
    Color zColor;
    int nNom;
    string [] noM;

    void Start()
    {
        zombieS = Random.Range(0, limite);
        aldeanoS = limite - zombieS;
        aldeanoS = Random.Range(0, aldeanoS);
        noM = new string[20]{"Brayan","Omaira","Carlos", "Jorge", "Omar", "David", "Mr Pickles", "Kim Jo Il", "Kim Il Sun", "Hittler", "Satan", "Javier", "José", "Blador", "Cesar", "Augusto", "Sara", "Salome", "Ana", "Jairo" };
        for (int i = 0; i < zombieS; i++) // Ciclo para crear zombies
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            Vector3 v = new Vector3(Random.Range(490, 500), 16.55f, Random.Range(815, 825));
            go.transform.position = v;
            switch (Random.Range(0, 3))
            {
                case 0:
                    zColor = Color.cyan;
                    break;
                case 1:
                    zColor = Color.green;
                    break;
                case 2:
                    zColor = Color.magenta;
                    break;
            }

            go.GetComponent<Renderer>().material.color = zColor;
            go.AddComponent<Rigidbody>();
            go.GetComponent<Rigidbody>().freezeRotation = true;
            go.name = i.ToString();
        }

        for (int i = 0; i < aldeanoS; i++) // Ciclo para crear aldeanos
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            string goName;
            int goEdad;

            Vector3 v = new Vector3(Random.Range(490, 500), 16.808f, Random.Range(815, 825));
            go.transform.position = v;
            go.GetComponent<Renderer>().material.color = Color.yellow;
            go.AddComponent<Rigidbody>();
            go.GetComponent<Rigidbody>().freezeRotation = true;

            nNom = Random.Range(0, 20);
            go.name = noM[nNom]; 
            goName = noM[nNom];

            goEdad = Random.Range(15, 100);
            print(DarMensaje(goName,goEdad));

        }
    }

    string DarMensaje(string goName, int goEdad)
    {
        string mensaje;
        string mensaje1 = "Hola Soy ";
        string mensaje2 = goName;
        string mensaje3 = " y tengo ";
        string mensaje4 = goEdad.ToString();
        string mensaje5 = " años";

        mensaje = mensaje1 + mensaje2 + mensaje3 + mensaje4 + mensaje5;
        return mensaje;
    }

    void Update()
    {
   
    }
}