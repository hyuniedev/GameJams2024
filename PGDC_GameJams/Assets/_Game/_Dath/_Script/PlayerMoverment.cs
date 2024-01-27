using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoverment : MonoBehaviour
{
    // Basic player moverment
    public GameObject handPos;
    [SerializeField] public float moveSpeed = 5f;
    [SerializeField] private float _jumpForce = 5f;
    // [SerializeField] private float _raycastDistance = 1.1f;
    // [SerializeField] private LayerMask _layerMask;
    [SerializeField] private Rigidbody2D _rigidbody2D;

    int _horizontalMove = 0;
    bool _jump = false;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
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
