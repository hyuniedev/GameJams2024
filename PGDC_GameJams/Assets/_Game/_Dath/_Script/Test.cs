using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Rigidbody2D _rb;
    public bool flip;
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.velocity = transform.up * 2f;
    }

    void Update()
    {
        transform.localRotation = Quaternion.Euler(flip ? 180 : 0, 0, 0);
    }
}
