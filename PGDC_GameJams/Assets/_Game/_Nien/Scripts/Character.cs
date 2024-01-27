using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float forceJump;
    private float addSpeed = 4f;

    private bool hasSkill;
    [SerializeField] private bool hasBoom = false;
    [SerializeField] private GameObject BoomSprite;
    public float ForceJump
    {
        get => forceJump;
        set => forceJump = value;
    }

    public bool HasBoom
    {
        get => hasBoom;
        set => hasBoom = value;
    }
    public float MoveSpeed
    {
        get => moveSpeed;

        set => moveSpeed = value;
    }

    public void setBoom()
    {
        BoomSprite.SetActive(hasBoom);
    }
    public void changeStateBoom()
    {
        // CoreGame.resetTimeBoom();
        hasBoom = !hasBoom;
        MoveSpeed = HasBoom ? MoveSpeed + addSpeed : MoveSpeed;
        BoomSprite.SetActive(hasBoom);
    }
}
