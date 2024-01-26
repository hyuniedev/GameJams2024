using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : Character
{
    private InputSystem input = null;
    private Vector2 directionMove = Vector2.zero;
    private Vector2 jumpingVec = Vector2.zero;
    private bool isRight;
    private bool isGround;
    private LayerMask _layerMask;
    [SerializeField] private Rigidbody2D rb;

    private void Awake()
    {
        input = new InputSystem();
        _layerMask = LayerMask.GetMask("Ground");
    }

    private void FixedUpdate()
    {
        DiChuyen();
        Nhay();
    }

    private void Nhay()
    {
        if (CheckGround() && jumpingVec.y > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x,jumpingVec.y * ForceJump);
        }else if (!CheckGround() && jumpingVec.y < 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpingVec.y * (ForceJump / 2));
        }
    }
    private void DiChuyen()
    {
        rb.velocity = new Vector2(MoveSpeed * directionMove.x,rb.velocity.y);
        if (directionMove.x > 0)
        {
            isRight = true;
        }else if (directionMove.x < 0)
        {
            isRight = false;
        }
        transform.rotation = Quaternion.Euler(new Vector3(0,isRight?0:180,0));
    }

    private bool CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 1.1f, _layerMask);
        return hit.collider != null;
    }
    private void OnMovePlayerEnter(InputAction.CallbackContext value)
    {
        directionMove = value.ReadValue<Vector2>();
    }

    private void OnMovePlayerExit(InputAction.CallbackContext value)
    {
        directionMove = new Vector2(0,rb.velocity.y);
    }

    private void OnJumpingEnter(InputAction.CallbackContext value)
    {
        jumpingVec = value.ReadValue<Vector2>();
    }

    private void OnJumpingExit(InputAction.CallbackContext value)
    {
        jumpingVec = new Vector2(rb.velocity.x, 0);
    }
    private void OnEnable()
    {
        input.Enable();
        input.Player.Movement.performed += OnMovePlayerEnter;
        input.Player.Movement.canceled += OnMovePlayerExit;
        input.Player.Movement.performed += OnJumpingEnter;
        input.Player.Movement.canceled += OnJumpingExit;
    }

    private void OnDisable()
    {
        input.Disable();
        input.Player.Movement.performed -= OnMovePlayerEnter;
        input.Player.Movement.canceled -= OnMovePlayerExit;
        input.Player.Movement.performed -= OnJumpingEnter;
        input.Player.Movement.canceled -= OnJumpingExit;
    }
}
