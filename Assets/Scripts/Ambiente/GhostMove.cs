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
    //GameObject ghost;

    public float tiempo;
    private float timer;

    private void Start()
    {
        timer = tiempo;
        //ghost = gameObject;
    }
    void Update()
    {
        //currentPoint = points[numberPoint];

       // Vector3 dir = currentPoint.position - transform.position;

        transform.position = points[numberPoint].transform.position;

        /*
        if(transform.position == currentPoint.position)
        {
          //  animator.Play("GhostIdle");
        }*/

        if (comenzar)
        {
            viajando = transform.position == currentPoint.position;
        }
        animator.SetBool("viajando", viajando);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
           
            numberPoint++;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                comenzar = true;
                timer = tiempo;
            }

            if (numberPoint == points.Length)
            {
                animator.Play("GhostDesa");
                gameObject.SetActive(false);
            }
            else
            {
                animator.Play("GhostDesa");
            }

        }
    }
}
