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
    public TextMeshPro textoDa�o;
    public int Dropvalue;
    public GameObject prefabArbol;
    public bool arbol;

    public void ResetearHp()
    {
        hp = 100;
        prefabArbol.GetComponent<BoxCollider2D>().enabled=true;

    }
    public void RecibirDa�o(int _da�o)
    {

        MostrarTextoDa�o(_da�o);

        hp -= _da�o;            //restar da�o
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
        
        onCaida.Invoke();                           // este evento se manda a llamar desde la animaci�n de caida
    }

    void MostrarTextoDa�o(int cantidad)
    {
        textoDa�o.gameObject.SetActive(false);      // apagar texto para que se resetee la animaci�n
        textoDa�o.text = cantidad.ToString();       // actualizar la cantidad de da�o en el texto
        textoDa�o.gameObject.SetActive(true);       // prender el texto para que muestre cuanto se le quito
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("hacha"))
        {

            int da�o = collision.GetComponent<Hacha>().da�oHacha.valor;     //obtiene el da�o del hacha
            collision.GetComponent<Hacha>().Golpeo();                       // ejecuta la funcion Golpeo dentro del hacha
            RecibirDa�o(da�o);                                              // Aplica da�o al arbol
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
