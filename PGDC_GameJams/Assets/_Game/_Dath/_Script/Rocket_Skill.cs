using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Skill : Skill
{
    float _timer = 0f;

    bool _active = false;
    bool _spawn = false;

    Vector2 direction;

    GameObject _rocket;


    [SerializeField] GameObject _rocketPrefab; // Thay đổi tên biến để tránh xung đột với biến _rocket
    private void Update()
    {
    }

    protected override void UseSkill(GameObject player)
    {
        if (!_spawn)
        {
            direction = player.GetComponent<Rigidbody2D>().velocity.normalized;
            _active = true;
            _spawn = true;
            _rocket = Instantiate(_rocketPrefab, transform.position, Quaternion.identity);
            // lay vector huong cua player
            _rocket.GetComponent<Rocket>().playerDirection = direction;
            Debug.Log("Spawn");

            // day lui player
            player.GetComponent<Rigidbody2D>().velocity = -direction * 20f;
            player.GetComponent<IEvent>().HasEvent(0.3f);
            // player.GetComponent<Rigidbody2D>().AddForce(-direction * 4500f);
        }
    }
}
