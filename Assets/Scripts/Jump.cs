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
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCapsule(groundCheck.position, new Vector2(2.3f, 0.8f), CapsuleDirection2D.Horizontal, 0, groundLayer);
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
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
