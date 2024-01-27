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

    protected GameObject GetPlayerInFront(Transform handPos)
    {
        // Draw line direction of player
        RaycastHit2D hit = Physics2D.Raycast(handPos.position, transform.forward, 10f, _layerMask);
        Debug.DrawRay(handPos.position, transform.forward * 10, Color.red);
        return hit == false ? null : hit.collider.gameObject;
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

    // protected List<GameObject> GetPlayerInCircle(GameObject player, float radius)
    // {
    //     void OnDrawGizmosSelected()
    //     {
    //         Gizmos.color = Color.red;
    //         Gizmos.DrawWireSphere(transform.position, radius);
    //     }
    //     Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius);
    //     List<GameObject> players = new List<GameObject>();
    //     foreach (Collider2D collider in colliders)
    //     {
    //         if (collider.gameObject.tag == "Player")
    //         {
    //             players.Add(collider.gameObject);
    //         }
    //     }
    //     return players.Count > 0 ? players : null;
    // }

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isCompareTag)
        {
            isCompareTag = true;
            UseSkill(other.gameObject);
            Debug.Log("Use skill");
        }
    }

}