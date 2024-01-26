using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : Character
{
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private LayerMask _layerMask;
    private Rigidbody2D rb;
    private bool isGround;
    private bool isRight;
    private float horizontal;
    private float vertical;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGround = checkGround();
        jump();
    }

    private void FixedUpdate()
    {
        move();
    }

    private void jump()
    {
        if (isGround)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                _rb.AddForce(Vector2.up * ForceJump);
            }
        }
    }
    private void move()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(horizontal) > 0)
        {
            _rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * this.MoveSpeed, _rb.velocity.y);
            if (horizontal > 0)
            {
                isRight = true;
            }
            else
            {
                isRight = false;
            }
            transform.rotation = Quaternion.Euler(new Vector3(0,isRight?0:180,0));
        }
        else
        {
            _rb.velocity = new Vector2(0,_rb.velocity.y);
        }
    }
    
    private bool checkGround()
    {
        Debug.DrawLine(this.transform.position,this.transform.position + Vector3.down * 1.1f,Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, _layerMask);
        return hit.collider != null;
    }
}
