using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp_Skill : Skill
{
    float _speedBoost = 12f;
    float _timeSpeedUp = 2f;

    protected override void UseSkill(GameObject player)
    {

        player.GetComponent<PlayerMoverment>().moveSpeed += _speedBoost;
        var playerScript = player.GetComponent<PlayerMoverment>();

        StartCoroutine(ResetSpeed(playerScript));
    }

    IEnumerator ResetSpeed(PlayerMoverment playerScript)
    {
        yield return new WaitForSeconds(_timeSpeedUp);
        playerScript.moveSpeed -= _speedBoost;
    }
}