using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp_Skill : MonoBehaviour
{
    bool isCompareTag = false;
    float _speedBoost = 12f;
    float _timeSpeedUp = 2f;
    GameObject _player;
    private void Update()
    {
        if (!isCompareTag) return;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;
        _timeSpeedUp -= Time.deltaTime;
        if (_timeSpeedUp <= 0)
        {
            _player.GetComponent<Move>().MoveSpeed -= _speedBoost;
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isCompareTag)
        {
            isCompareTag = true;
            // other.GetComponent<IEventHappen>().EventHappen(true);
            _player = other.gameObject;
            _player.GetComponent<Move>().MoveSpeed += _speedBoost;
            // other.GetComponent<IEventHappen>().EventHappen(false);
        }
    }
}