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
    [SerializeField] private GameObject spritePlayer;
    [SerializeField] private int PlayerNumber;
    public GameObject hand;
    private float timeHoldBoom = 0;

    private void Awake()
    {
        input = new InputSystem();
        _layerMask = LayerMask.GetMask("Ground");
        this.setBoom();
    }

    private void FixedUpdate()
    {
        if(HasBoom) timeHoldBoom += Time.fixedDeltaTime * 2;
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
        spritePlayer.transform.rotation = Quaternion.Euler(new Vector3(0,isRight?0:180,0));
    }

    private bool CheckGround()
    {
        RaycastHit2D hit = Physics2D.Raycast(this.transform.position, Vector2.down, 1.1f, _layerMask);
        return hit.collider != null;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (timeHoldBoom > 0.8f)
        {
            if (other.gameObject.tag.Equals("Player"))
            {
                other.gameObject.GetComponent<Character>().changeStateBoom();
                this.changeStateBoom();
                timeHoldBoom = 0;
            }
        }
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
        if (PlayerNumber==1)
        {
            input.Player.Player1.performed += OnMovePlayerEnter;
            input.Player.Player1.canceled += OnMovePlayerExit;
            input.Player.Player1.performed += OnJumpingEnter;
            input.Player.Player1.canceled += OnJumpingExit;
        }else if (PlayerNumber==2)
        {
            input.Player.Player2.performed += OnMovePlayerEnter;
            input.Player.Player2.canceled += OnMovePlayerExit;
            input.Player.Player2.performed += OnJumpingEnter;
            input.Player.Player2.canceled += OnJumpingExit;
        }else if (PlayerNumber==3)
        {
            input.Player.Player3.performed += OnMovePlayerEnter;
            input.Player.Player3.canceled += OnMovePlayerExit;
            input.Player.Player3.performed += OnJumpingEnter;
            input.Player.Player3.canceled += OnJumpingExit;
        }else if (PlayerNumber==4)
        {
            input.Player.Player4.performed += OnMovePlayerEnter;
            input.Player.Player4.canceled += OnMovePlayerExit;
            input.Player.Player4.performed += OnJumpingEnter;
            input.Player.Player4.canceled += OnJumpingExit;
        }
    }

    private void OnDisable()
    {
        input.Disable();
        if (PlayerNumber==1)
        {
            input.Player.Player1.performed -= OnMovePlayerEnter;
            input.Player.Player1.canceled -= OnMovePlayerExit;
            input.Player.Player1.performed -= OnJumpingEnter;
            input.Player.Player1.canceled -= OnJumpingExit;
        }else if (PlayerNumber==2)
        {
            input.Player.Player2.performed -= OnMovePlayerEnter;
            input.Player.Player2.canceled -= OnMovePlayerExit;
            input.Player.Player2.performed -= OnJumpingEnter;
            input.Player.Player2.canceled -= OnJumpingExit;
        }else if (PlayerNumber==3)
        {
            input.Player.Player3.performed -= OnMovePlayerEnter;
            input.Player.Player3.canceled -= OnMovePlayerExit;
            input.Player.Player3.performed -= OnJumpingEnter;
            input.Player.Player3.canceled -= OnJumpingExit;
        }else if (PlayerNumber==4)
        {
            input.Player.Player4.performed -= OnMovePlayerEnter;
            input.Player.Player4.canceled -= OnMovePlayerExit;
            input.Player.Player4.performed -= OnJumpingEnter;
            input.Player.Player4.canceled -= OnJumpingExit;
        }
    }

    public bool checkMove()
    {
        return rb.velocity.x != 0;
    }

    public bool checkRight()
    {
        return rb.velocity.x > 0;
    }
}
