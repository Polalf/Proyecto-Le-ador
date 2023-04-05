using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRep : MonoBehaviour
{
    public int valorRep;
   // public Animator animator;
    public AudioClip reparacionFx;
    
    private void OnTriggerEnter2D(Collider2D colision)
    {
        if (colision.CompareTag("Player"))
        {
            colision.gameObject.GetComponent<Player>().hacha.RepararHacha(valorRep);

            AudioManager.manager.ReproducirSonidoFx(reparacionFx);

            Destroy(gameObject);
        }
    }
}
