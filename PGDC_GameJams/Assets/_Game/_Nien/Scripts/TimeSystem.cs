using System;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class TimeSystem : MonoBehaviour
{
    [SerializeField] private float speedTime;
    [SerializeField] private Text txtBoomTime;
    private static int giay = 15;
    private float congdon = 0;
    private bool isEnd = false;
    void FixedUpdate()
    {
        String g = giay.ToString().Length == 1 ? "0" + giay : giay+"";
        txtBoomTime.text = "00" + ":" + g;
        congdon += Time.fixedDeltaTime * speedTime;
        if (congdon > 1)
        {
            giay--;
            congdon = 0;
        }
        if (giay == 0)
        {
            Character[] dsCharacter = FindObjectsOfType<Character>();
            foreach (var VARIABLE in dsCharacter)
            {
                if (VARIABLE.HasBoom)
                {
                    VARIABLE.gameObject.SetActive(false);
                }
            }
            dsCharacter = FindObjectsOfType<Character>();
            if (dsCharacter.Length > 1)
            {
                dsCharacter[0].changeStateBoom();
            }
            else
            {
                Time.timeScale = 0;
            }
        }
    }

    public static void resetTimeBoom()
    {
        giay = 15;
    }
}
