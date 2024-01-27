using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnet_Skill : Skill
{

    float _force = 4f;

    private void Update()
    {

    }
    protected override void UseSkill(GameObject player)
    {
        Debug.Log("Magnet");
        // lấy vị trí tay của player
        Transform handPos = player.GetComponent<PlayerMoverment>().handPos.transform;
        // lấy player ở phía trước bị chiếu tia
        // var playerScript = player.GetComponent<PlayerMoverment>();
        GameObject playerGotHit = GetPlayerInFront(handPos);
        if (playerGotHit != null)
        {
            var rb = playerGotHit.GetComponent<Rigidbody2D>();
            // thêm lực ngược lại với hướng của player vào player bị chiếu tia
            rb.AddForce(GetDirectionOfPlayer(playerGotHit) * _force, ForceMode2D.Impulse);
        }

    }

}