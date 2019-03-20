using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ald = NPC.Ally;
using zon = NPC.Enemy;
using UnityEngine.UI;

/// <summary>
/// Se toma de referencias los namespces de otros scripts para facilitar el llamado
/// </summary>
public class Taller3 : MonoBehaviour
{

    public Text zombies;
    public Text aldeanos;
    int camp;
    int infec;
    GameObject[] zombian, aldino;
   
    /// <summary>
    /// se llenan los array de aldeano y zombie con los ojetos de tags correspondientes  
    /// </summary>

    void Start()
    {
        Creator creator = new Creator(Random.Range(5, 15));
        zombian = GameObject.FindGameObjectsWithTag("Zombie");
        aldino = GameObject.FindGameObjectsWithTag("Villiger");
    }
    private void Update()
    {
        foreach (GameObject item in zombian)
        {
            infec = zombian.Length;
            zombies.text = infec.ToString();
        }
        foreach (GameObject item in aldino)
        {
           camp =  aldino.Length;
           aldeanos.text = camp.ToString();
        }
    }
}

public class Creator
{

    /// <summary>
    /// usamos un valor random para determinar cuantos GameObjects habran.
    /// de manera aleatorea se le otorgan componentes a estos GameObjects
    /// </summary>
    const int MAXINS = 26;
    public readonly float probability;
    public Creator(float prob)
    {
        probability = prob;
        int unic = 0;


        for (int i = 0; i < Random.Range(probability, MAXINS); i++)
        {
            int entidades = Random.Range(unic, 3);

            if (unic == 0)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.AddComponent<Hero>().Init();
                unic = unic + 1;
            }
            if (entidades == 1)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.AddComponent<ald.Aldeano>().Comun();
                go.tag = "Villiger";
            }
            if (entidades == 2)
            {
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.AddComponent<zon.Walker>().SinCerbro();
                go.tag = "Zombie";
            }
        }

    }
}
public class Hero : MonoBehaviour
{
    /// <summary>
    /// se realiza una referencia para los scripts de movimiento y mirar del Heroe (jugador)
    /// Agregamos los componentes necesarios para realizar collisiones y se desactiva el uso de graveda 
    /// tambien se activan todas los constrains para hacer que solo se pueda mover por el codigo y no por alguna colision
    /// </summary>
    Movement movement;
    Look look;


    public void Init()
    {

        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        gameObject.name = "Hero";
        rb.useGravity = false;
        rb.constraints = RigidbodyConstraints.FreezeAll;
        // se le agregan los scripts de movimiento y mirar al jugador 
        movement = gameObject.AddComponent<Movement>();
        look = gameObject.AddComponent<Look>();
        gameObject.AddComponent<Camera>();
        // determina una velocidad al azar para entregarcela al metodo de movimiento mas adelante

    }
    /// <summary>
    /// llama a los constructores en las clases de Movement y Look
    /// </summary>
    private void Update()
    {
        movement.Move();
        look.Arround();
    }
    /// <summary>
    /// se toman los valores almacendos en el estruc para imprimirlos cada que el heroe colisione con 
    /// el respectivo GameObject
    /// </summary>
    /// <param name="collision"></param>
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<zon.Walker>())
        {
            InfoZomb info = collision.gameObject.GetComponent<zon.Walker>().GetInfo();
            Debug.Log("Waaar quiero comer " + info.gusto);
        }
        if (collision.gameObject.GetComponent<ald.Aldeano>())
        {
            InfoAlde info = collision.gameObject.GetComponent<ald.Aldeano>().GetInfo();
            Debug.Log("soy " + info.name + " y tengo " + info.edad);
        }
    }
}
