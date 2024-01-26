using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class MovePlayer : Character
{
    [SerializeField] private Rigidbody2D _rb;
    private LayerMask _layerMask;
    private bool isRight;
    private float horizontal;
    private float vertical;

    private void Awake()
    {
        _layerMask = LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        move();
    }

    public void Jump(InputAction.CallbackContext context)
    {
        
        if (checkGround() && context.performed)
        {
            _rb.velocity = new Vector2(_rb.velocity.x,ForceJump);
        }
        if(context.canceled && _rb.velocity.y > 0f)
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _rb.velocity.y * 0.5f);
        }
    }
    private void move()
    {
        
        _rb.velocity = new Vector2(horizontal * Time.fixedDeltaTime * this.MoveSpeed, _rb.velocity.y);
        if (horizontal > 0 && !isRight)
        {
            isRight = true;
        }
        else if(horizontal < 0 && isRight)
        {
            isRight = false;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0,isRight?0:180,0));
    }
    
    private bool checkGround()
    {
        Debug.DrawLine(this.transform.position,this.transform.position + Vector3.down * 1.1f,Color.red);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 1.1f, _layerMask);
        return hit.collider != null;
    }

    public void Move(InputAction.CallbackContext context)
    {
        horizontal = context.ReadValue<Vector2>().x;
        
    }
}
