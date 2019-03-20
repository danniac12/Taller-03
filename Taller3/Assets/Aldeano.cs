using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NPC
{
    namespace Ally
    {
        public class Aldeano : MonoBehaviour
        {

            /// <summary>
            /// se realiza una enumeracion para guardar los posibles nombres de los aldeanos 
            /// y se le da nombre a esa enumeracion, tambien creamos un espacio para almacenar la edad de los aldeanos
            /// </summary>
            int age;
            public enum Nombres
            {
                santiago, rio, tere, troy, Joe,
                Aleesha, Abdirahman, Kaycee, Chantal, Cherise,
                Taiba, Sanah, Jack, Pascal, Kelly,
                Everly, Muna, Anya, Marguerite, Kali

            }

            public Nombres nombres;
            /// <summary>
            /// igual en en el heroe se le agrega un comoponente  Rigidbody y se desactivan las influencias externas
            /// para que no se mueva debido a colisiones 
            /// le damos un valor random a la edad entre 15 y 100 
            /// y tomamos un nombre random del enumerador ademas de ponerlo en un lugar aleatorio del mapa 
            /// entre las posiciones 10 y -10 en los ejes "x" y "z"
            /// </summary>
            public void Comun()
            {

                age = Random.Range(15, 100);
                nombres = (Nombres)Random.Range(0, 21);
                Rigidbody rb = this.gameObject.AddComponent<Rigidbody>();
                rb.useGravity = false;
                rb.isKinematic = true;
                this.gameObject.name = nombres.ToString();
                float x = Random.Range(-10, 10);
                float z = Random.Range(-10, 10);
                this.gameObject.transform.position = new Vector3(x, 0, z);
            }
            /// <summary>
            /// almacenamos en el struct del aldeano el nombre que le dimos aleatoreamente
            /// y su edad
            /// </summary>
            /// <returns></returns>
            public InfoAlde GetInfo()
            {
                InfoAlde infoAlde = new InfoAlde();
                infoAlde.edad = age;
                infoAlde.name = nombres.ToString();
                return infoAlde;
            }
        }
    }
}
