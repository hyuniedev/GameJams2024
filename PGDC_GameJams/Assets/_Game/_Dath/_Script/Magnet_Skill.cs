using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet_Skill : Skill
{
    private bool active;

    [SerializeField] float _radius = 5f;
    [SerializeField] float _force = 5f;
    GameObject _player;
    float _time = 3f;
    bool _spawned = false;
    float _timeCount = 0f;
    GameObject magnet;
    GameObject _handPos;


    [SerializeField] private GameObject _magnetGameObject;
    private void Update()
    {
        if (!active) { return; }
        if (!_spawned)
        {
            _handPos = _player.GetComponent<Move>().hand;
            magnet = Instantiate(_magnetGameObject, _handPos.transform);
            _spawned = true;
        }
        magnet.GetComponent<Magnet>().facingRight = _player.GetComponent<Move>().checkRight();
        _timeCount += Time.deltaTime;


        // disable
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;


        if (_timeCount >= _time)
        {
            active = false;
            // Hết thời gian sẽ hủy magnet
            _player.GetComponent<IEventHappen>().EventHappen(false);
            Destroy(magnet);
            Destroy(gameObject);
        }
    }

    protected override void UseSkill(GameObject player)
    {
        active = true;
        Debug.Log(active);
        _player = player;
        Debug.Log(_player);
    }

    new void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && !isCompareTag)
        {

            other.GetComponent<IEventHappen>().EventHappen(true);
            isCompareTag = true;
            UseSkill(other.gameObject);
        }
    }
}