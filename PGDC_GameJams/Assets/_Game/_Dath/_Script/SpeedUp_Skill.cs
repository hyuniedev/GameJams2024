using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp_Skill : Skill
{
    float _speedBoost = 12f;
    float _timeSpeedUp = 2f;

    protected override void UseSkill(GameObject player)
    {

        player.GetComponent<Move>().MoveSpeed += _speedBoost;
        var playerScript = player.GetComponent<Move>();

        StartCoroutine(ResetSpeed(playerScript));
    }

    IEnumerator ResetSpeed(Move playerScript)
    {
        yield return new WaitForSeconds(_timeSpeedUp);
        playerScript.MoveSpeed -= _speedBoost;
    }
}