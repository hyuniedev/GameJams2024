using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] private float speedTime;
    [SerializeField] private Text txtBoomTime;
    [SerializeField] private int phut = 0;

    [SerializeField] private int giay = 0;
    private float congdon = 0;
    private bool isEnd = false;
    void FixedUpdate()
    {
        if (!isEnd)
        {
            String p = phut.ToString().Length == 1 ? "0" + phut : phut+"";
            String g = giay.ToString().Length == 1 ? "0" + giay : giay+"";
            txtBoomTime.text = p + ":" + g;
            congdon += Time.fixedDeltaTime * speedTime;
            if (congdon > 1)
            {
                giay--;
                congdon = 0;
            }

            if (giay < 0)
            {
                phut--;
                giay = 59;
            }
        }

        if (phut == 0 && giay == 0)
        {
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
}
