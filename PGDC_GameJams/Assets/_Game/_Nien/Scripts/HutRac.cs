using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HutRac : MonoBehaviour
{
    private bool check = false;

    private void Update()
    {
        if (check)
        {
            Collider2D[] ds = Physics2D.OverlapCircleAll(transform.position, 15f);
            foreach (var VARIABLE in ds)
            {
                if (VARIABLE.gameObject.tag.Equals("Player"))
                {
                    Vector2 direc = this.transform.position - VARIABLE.transform.position;
                    VARIABLE.gameObject.GetComponent<Rigidbody2D>().velocity -= direc.normalized * 20;
                }
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            check = true;
        }
    }
}
