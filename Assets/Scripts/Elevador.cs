using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevador : MonoBehaviour
{
    public Transform pointA, pointB;
    public Transform proxPointA, proxPointB;
    public float speed;
    Transform currentPoint;
    public bool targetA;


    private void Start()
    {
        if (targetA)
        {
            currentPoint = pointA;

        }
        else
        {
            currentPoint = pointB;
        }
    }
    void Update()
    {

        Vector3 dir = currentPoint.position - transform.position;
        transform.position += dir * speed * Time.deltaTime;
        if (targetA)
        {
            currentPoint = pointA;

        }
        else
        {
            currentPoint = pointB;
        }


        if (transform.position.y <= pointA.position.y && transform.position.y >= proxPointA.position.y)
        {
            targetA = false;
        }
        else if (transform.position.y >= pointB.position.y && transform.position.y <= proxPointB.position.y)
        {
            targetA = true;
        }
        
      
    }
    
}
