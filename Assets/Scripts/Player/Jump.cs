using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] private float jumpForce;
    [SerializeField] private float fallMulti;

    public Transform groundCheck;
    public LayerMask groundLayer;
    bool isGrounded;
    bool jumping;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumping = true;
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(2.3f, 0.8f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (jumping && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumping = false;
        }

        if (!isGrounded)
        {
            rb.gravityScale += fallMulti * Time.deltaTime;
        }
        else
        {
            rb.gravityScale = 1;
        }
    }
}
