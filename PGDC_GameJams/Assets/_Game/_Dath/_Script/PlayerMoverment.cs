using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverment : MonoBehaviour
{
    // Basic player moverment
    public GameObject handPos;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 15f;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    public bool allowMove;
    int _horizontalMove = 0;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log(handPos.name);
    }

    private void Update()
    {
        if (!allowMove) return;
        _horizontalMove = (int)Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(_horizontalMove) > 0)
        {
            _rigidbody2D.velocity = new Vector2(_horizontalMove * moveSpeed, _rigidbody2D.velocity.y);
        }
        if (Input.GetButtonDown("Jump"))
        {
            _rigidbody2D.velocity = new Vector2(_rigidbody2D.velocity.x, _jumpForce);
        }


    }




}
