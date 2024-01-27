
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Magnet : MonoBehaviour
{
    float _radius = 15f;
    float _strength = 1f;
    float _maxStrength = 5f;
    private void Update()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _radius);
        foreach (Collider2D collider in colliders)
        {
            GameObject playerVictim = collider.gameObject;

            if (playerVictim.CompareTag("Player") && !transform.IsChildOf(playerVictim.transform))
            {
                if (playerVictim.transform.position.x > transform.position.x)
                {

                    Debug.Log("Player Victim" + playerVictim.name);
                    Rigidbody2D rb = playerVictim.GetComponent<Rigidbody2D>();
                    Vector2 direction = transform.position - playerVictim.transform.position;
                    // rb.AddForce(direction * 2f);
                    rb.velocity = direction * 2f;
                }

            }
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _radius);

    }

}