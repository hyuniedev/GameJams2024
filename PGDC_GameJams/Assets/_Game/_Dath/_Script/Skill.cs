using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    private bool isCompareTag = false;
    [SerializeField] private LayerMask _layerMask;

    protected virtual void UseSkill(GameObject player)
    {
    }

    // no deo chay ???
    protected GameObject GetPlayerInFront(Transform handPos)
    {
        // Draw line direction of player
        RaycastHit2D hit = Physics2D.Raycast(handPos.position, handPos.forward, 50f, _layerMask);
        Debug.DrawRay(handPos.position, handPos.forward * 50f, Color.red);

        return hit.collider != null ? hit.collider.gameObject : null;
    }


    protected Vector2 GetDirectionOfPlayer(GameObject player)
    {
        Vector2 playerDirection = player.transform.forward;
        return playerDirection;
    }

    // Draw line direction of player
    protected void DrawLineDirectionOfPlayer(GameObject player)
    {
        Vector2 playerDirection = GetDirectionOfPlayer(player);
        Debug.DrawRay(player.transform.position, playerDirection * 10, Color.red);
    }



    // Todo : Sử dụng trong script của rocket

    protected List<GameObject> GetPlayerInCircle(GameObject player, float radius)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        List<GameObject> players = new List<GameObject>();

        foreach (Collider2D collider in colliders)
        {
            GameObject playerObject = collider.gameObject;
            if (playerObject.CompareTag("Player"))
            {
                players.Add(playerObject);
            }
        }

        return players.Count > 0 ? players : null;
    }

    public void ShockWave(Transform trans, float radius, float time, float boomForce)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (Collider2D collider in colliders)
        {
            GameObject playerArround = collider.gameObject;

            if (playerArround.CompareTag("Player"))
            {
                playerArround.GetComponent<Rigidbody2D>().AddForce((playerArround.transform.position - transform.position).normalized * boomForce, ForceMode2D.Impulse);
                playerArround.GetComponent<IEvent>().HasEvent(time);
            }
        }
    }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isCompareTag)
        {
            isCompareTag = true;
            UseSkill(other.gameObject);
            Destroy(gameObject);
        }
    }


}