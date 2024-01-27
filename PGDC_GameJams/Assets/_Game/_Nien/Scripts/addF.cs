using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addF : MonoBehaviour
{
    private GameObject tar;
    private bool isCheck = false;

    private void Update()
    {
        if (isCheck)
        {
            tar.GetComponent<Rigidbody2D>().velocity += new Vector2(100, 0);
        }
       
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isCheck = true;
            tar = other.gameObject;
        }
    }
}
