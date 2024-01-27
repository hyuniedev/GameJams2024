using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp_Skill : Skill
{
    float _speedBoost = 12f;
    float _timeSpeedUp = 2f;

    protected override void UseSkill(GameObject player)
    {

        player.GetComponent<MoveTest>().MoveSpeed += _speedBoost;
        MoveTest playerScript = player.GetComponent<MoveTest>();

        StartCoroutine(ResetSpeed(playerScript));
    }

    // IEnumerator ResetSpeed(MoveTest playerScript)
    // {
    //     Debug.Log("Call Reset Speed");
    //     // yield return new WaitForSeconds(_timeSpeedUp);
    //     yield return new WaitForSeconds(_timeSpeedUp);
    //     playerScript.MoveSpeed -= _speedBoost;
    // }
    IEnumerator ResetSpeed(MoveTest playerScript)
    {
        Debug.Log("Call Reset Speed");
        yield return new WaitForSeconds(_timeSpeedUp);
        Debug.Log("After WaitForSeconds");
        playerScript.MoveSpeed -= _speedBoost;
        Debug.Log("After reducing speed");
    }
}