using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] private float speedTime;
    [SerializeField] private Text txtBoomTime;
    private static int giay = 15;
    private float congdon = 0;
    private bool isEnd = false;
    void FixedUpdate()
    {
        if (!isEnd)
        {
            String g = giay.ToString().Length == 1 ? "0" + giay : giay+"";
            txtBoomTime.text = "00" + ":" + g;
            congdon += Time.fixedDeltaTime * speedTime;
            if (congdon > 1)
            {
                giay--;
                congdon = 0;
            }
        }

        if (giay == 0)
        {
            Time.timeScale = 0;
            isEnd = true;
            foreach (var VARIABLE in FindObjectsOfType<Character>())
            {
                if (VARIABLE.HasBoom)
                {
                    txtBoomTime.text = VARIABLE.gameObject.name + "";
                }
            }
        }
    }

    public static void resetTimeBoom()
    {
        giay = 15;
    }
}
