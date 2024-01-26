using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float forceJump;
    private bool hasSkill;
    public float ForceJump
    {
        get => forceJump;
        set => forceJump = value;
    }
    public float MoveSpeed
    {
        get => moveSpeed;
        set => moveSpeed = value;
    }

    public bool HasSkill
    {
        get => hasSkill;
        set => hasSkill = value;
    }
}
