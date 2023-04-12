using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{
    public Transform[] points;
    public int numberPoint=0;
    public Transform currentPoint;
    public float speed;
    public Animator animator;
    bool comenzar;
    bool viajando;

    void Update()
    {
        currentPoint = points[numberPoint];

        Vector3 dir = currentPoint.position - transform.position;

        transform.position += speed * dir*Time.deltaTime;

        /*
        if(transform.position == currentPoint.position)
        {
          //  animator.Play("GhostIdle");
        }*/

        if(comenzar)
        {
            viajando = transform.position == currentPoint.position;
        }
        animator.SetBool("viajando", viajando);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            comenzar = true;
            numberPoint++;
            if(numberPoint == points.Length)
            {
               gameObject.SetActive(false);
            }
            else
            {
                animator.Play("GhostDesa");
            }

        }
    }
}
