using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    protected bool isCompareTag = false;
    [SerializeField] private LayerMask _layerMask;

    protected virtual void UseSkill(GameObject player)
    {
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
            other.GetComponent<IEventHappen>().EventHappen(true);
            UseSkill(other.gameObject);
            other.GetComponent<IEventHappen>().EventHappen(false);
            Destroy(gameObject);
        }
    }


}