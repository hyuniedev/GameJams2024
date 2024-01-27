using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    // Start is called before the first frame update
    public int Speed;
    Rigidbody2D rb;
    float Horizontal;
    public float JumpForce;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if (Horizontal != 0) {
            rb.velocity = new Vector2(Horizontal * Speed * Time.fixedDeltaTime, rb.velocity.y);
            
        }
        if (Input.GetButtonDown("Jump")){
            rb.velocity = new Vector2(0,JumpForce);
        }

    }
}
