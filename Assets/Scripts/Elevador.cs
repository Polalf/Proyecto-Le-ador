using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    public Transform pointA, pointB;
    public float speed;
    Transform currentPoint;
    public bool targetA;

    private void Start()
    {
        currentPoint = pointA;
    }
    void Update()
    {

        Vector3 dir = currentPoint.position - transform.position;
        
        if(targetA)
        {
            currentPoint = pointA;

        }
        else
        {
            currentPoint = pointB;
        }


        if(transform.position == pointA.position)
        {
             targetA = false;
        }
        else if(transform.position == pointB.position)
        {
            targetA = true;
        }
        transform.position += dir * speed * Time.deltaTime;
      
    }
}
