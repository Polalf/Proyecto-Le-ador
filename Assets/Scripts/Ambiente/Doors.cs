using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

public class Doors : MonoBehaviour
{
   // public UnityEvent abrirPuerta;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            //abrirPuerta.Invoke();
            gameObject.GetComponent<Puzzles>().solve=true;
        }
    }
}
