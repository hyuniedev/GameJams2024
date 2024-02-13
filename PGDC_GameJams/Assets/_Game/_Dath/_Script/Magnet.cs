
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    public bool facingRight = true;
    public float boundInsideRadius = 8f;
    float _radius = 25f;
    float _strength = 25f;
    float _maxStrength = 5f;
    Vector2 testDirection;

    private void Update()
    {

        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius);
        foreach (Collider2D collider in colliders)
        {
            GameObject playerVictim = collider.gameObject;

            if (playerVictim.CompareTag("Player") && !transform.IsChildOf(playerVictim.transform))
            {
                Debug.Log(playerVictim.name);
                float boundInside = Vector2.Distance(transform.position, playerVictim.transform.position);
                if (boundInside < boundInsideRadius) return;
                // float checkPos = playerVictim.transform.position.x - transform.position.x;
                Rigidbody2D rb = playerVictim.GetComponent<Rigidbody2D>();
                Vector2 direction = transform.position - playerVictim.transform.position;


                // Test
                testDirection = direction;
                // -- Test
                direction.Normalize();

                if (facingRight)
                {
                    float distanceX = playerVictim.transform.position.x - transform.position.x;
                    if (distanceX > 0)
                    {

                        rb.velocity = direction * _strength;
                        Debug.Log(rb.velocity);
                    }
                }
                if (!facingRight)
                {
                    float distanceX = playerVictim.transform.position.x - transform.position.x;
                    if (distanceX < 0)
                    {
                        rb.velocity = direction * _strength;
                        Debug.Log(rb.velocity);
                    }
                }

            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);
        Gizmos.DrawWireSphere(transform.position, boundInsideRadius);
        Gizmos.DrawLine(transform.position, transform.position + new Vector3(testDirection.x, testDirection.y, 0));
    }

}