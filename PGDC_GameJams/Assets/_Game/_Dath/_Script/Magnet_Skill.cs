using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet_Skill : Skill
{
    bool _active = false;
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
        if (!_active) return;
        if (!_spawned)
        {
            _handPos = _player.GetComponent<Move>().hand;
            magnet = Instantiate(_magnetGameObject, _handPos.transform);
            _spawned = true;
        }
        magnet.GetComponent<Magnet>().facingRight = _player.GetComponent<Move>().checkRight();
        _timeCount += Time.deltaTime;
        if (_timeCount >= _time)
        {
            _active = false;
            // Hết thời gian sẽ hủy magnet
            Destroy(magnet);
        }
    }

    protected override void UseSkill(GameObject player)
    {
        _active = true;
        _player = player;
    }

}