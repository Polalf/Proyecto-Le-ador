using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ElevadorV2 : MonoBehaviour
{
    public float speed;
    public Transform pointA, pointB;
    //public float tiempoParaMoverse;
    //float timer = 0;
    //bool canMove;
    void Update()
    {
        //if(timer>= tiempoParaMoverse)
        //{
        //    canMove = true;

        //}
        
        if(transform.position.y >= pointA.position.y)
        {
            speed *= -1;

        }
        else if(transform.position.y <= pointB.position.y)
        {
            speed *= -1;
        }
        transform.Translate(Vector2.up * Time.deltaTime * speed);
    }
    
}
