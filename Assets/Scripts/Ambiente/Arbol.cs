using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Cinemachine;
using TMPro;

public class Arbol : MonoBehaviour
{
    public int hp;
    public UnityEvent onHit, onDead, onCaida;
    public TextMeshPro textoDaño;
    public int Dropvalue;
    public GameObject prefabArbol;
    public bool arbol;

    public void ResetearHp()
    {
        hp = 100;
        prefabArbol.GetComponent<BoxCollider2D>().enabled=true;

    }
    public void RecibirDaño(int _daño)
    {

        MostrarTextoDaño(_daño);

        hp -= _daño;            //restar daño
        if (hp < 1)             // si no tengo hp ejecutar Muere sino ejecutar Hit
        {
            Muere();           
        } 
        else
        {
            Hit();
        }
    }

    void Hit()
    {
        onHit.Invoke();                             // por cada golpe se ejecuta este evento
    }

    void Muere()
    {
        
        onDead.Invoke();                            // cuando se queda sin hp se ejecuta este evento
    }

    void Caida()
    {
        GameManager.gm.AgregarMadera(Dropvalue);
        if(arbol)
        {
            SpawnearOtroArbol(); 
        }
        
        onCaida.Invoke();                           // este evento se manda a llamar desde la animación de caida
    }

    void MostrarTextoDaño(int cantidad)
    {
        textoDaño.gameObject.SetActive(false);      // apagar texto para que se resetee la animación
        textoDaño.text = cantidad.ToString();       // actualizar la cantidad de daño en el texto
        textoDaño.gameObject.SetActive(true);       // prender el texto para que muestre cuanto se le quito
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("hacha"))
        {

            int daño = collision.GetComponent<Hacha>().dañoHacha.valor;     //obtiene el daño del hacha
            collision.GetComponent<Hacha>().Golpeo();                       // ejecuta la funcion Golpeo dentro del hacha
            RecibirDaño(daño);                                              // Aplica daño al arbol
        }
    }

    void SpawnearOtroArbol()
    {
        Vector3 posicionDelOtroArbol = transform.position;
        posicionDelOtroArbol.x += Random.Range(-8,8);
        GameObject elOtroArbol = Instantiate(prefabArbol,posicionDelOtroArbol, Quaternion.identity);
        elOtroArbol.SetActive(true);
        
        elOtroArbol.transform.localScale = Vector3.one * Random.Range(.7f ,1.5f);

        elOtroArbol.GetComponent<Arbol>().ResetearHp();
    }

}
