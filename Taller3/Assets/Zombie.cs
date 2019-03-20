using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    

    
    namespace Enemy
    {

        public class Walker : MonoBehaviour
        {
            /// <summary>
            /// declaramos 2 enumeradores uno para el estado del zombie y otro para la comida preferida
            /// asi como abrimos un espacio para lamacenar un contador que usaremos mas adelante
            /// </summary>

            float t;

            public enum Comer
            {
                Cerebro,
                Pierna,
                Vesicula,
                Brazo,
                Costilla
            }

            public enum Estado
            {
                idel,
                moving,
                rotating
            }

            Comer comer;
            Estado estado;
            /// <summary>
            /// le otorgamso un rigidboy como en las otras dos calses para efectuar la colisiones
            /// y congelamos en todas las posiciones para evitar comportamientos erraticos debido a estas colisiones
            /// se determina de que color sera el zombie de maenra aleatorea
            /// y se posicionea en un lugar random del mundo entre 10 y menos 10 de los ejes "z" y "x"
            /// </summary>
            public void SinCerbro()
            {
                Rigidbody rb;
                comer = (Comer)Random.Range(0, 5);

                int cambio = Random.Range(1, 4);
                if (cambio == 1)
                {

                    Renderer color = this.gameObject.GetComponent<Renderer>();
                    color.material.color = Color.green;
                    this.gameObject.name = "Zombie";
                    rb = this.gameObject.AddComponent<Rigidbody>();
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    rb.useGravity = false;
                }
                if (cambio == 2)
                {

                    Renderer color = this.gameObject.GetComponent<Renderer>();
                    color.material.color = Color.cyan;
                    this.gameObject.name = "Zombie";
                    rb = this.gameObject.AddComponent<Rigidbody>();
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    rb.useGravity = false;
                }
                if (cambio == 3)
                {

                    Renderer color = this.gameObject.GetComponent<Renderer>();
                    color.material.color = Color.magenta;
                    this.gameObject.name = "Zombie";
                    rb = this.gameObject.AddComponent<Rigidbody>();
                    rb.constraints = RigidbodyConstraints.FreezeAll;
                    rb.useGravity = false;

                }
                float x = Random.Range(-10, 10);
                float z = Random.Range(-10, 10);
                this.gameObject.transform.position = new Vector3(x, 0, z);

            }
            /// <summary>
            /// almacenamos en el struct del zombi su preferencia alimenticia
            /// </summary>
            public InfoZomb GetInfo()
            {
                InfoZomb infoZomb = new InfoZomb();
                infoZomb.gusto = comer.ToString();
                return infoZomb;
            }
            /// <summary>
            /// /utilisamos un contador "t" para determinar el tiempo entre cada estado del zombie 
            /// y acceder al siguiente estado de manera alkeatorea cada 5 segundos y cambia la direccion en la que mira
            /// en el estado moving el zombie se desplaza hacia el vector z con una velociad reducida 
            /// </summary>
            private void Update()
            {
                t += Time.deltaTime;
                if (t >= 3)
                {
                    estado = (Estado)Random.Range(0, 3);

                    t = 0;
                }
                switch (estado)
                {
                    case Estado.idel:
                        break;
                    case Estado.moving:

                        this.gameObject.transform.Translate(transform.forward * 0.02f);
                        break;
                    case Estado.rotating:
                        this.gameObject.transform.Rotate(0, Random.Range(1f, 15f), 0, 0);
                        //this.gameObject.transform.rotation = new Quaternion(0, Random.Range(1, 361), 0,0);
                        break;
                    default:
                        break;
                }
             
            }
        }
    }
}


