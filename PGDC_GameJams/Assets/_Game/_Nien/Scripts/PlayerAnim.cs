using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Move _m;
    [SerializeField] private Animator _am;
    private int currentState;
    private void Start()
    {
        _m = GetComponent<Move>();
    }
    private int GetState()
    {
        if (!_m.CheckGround()) return Jump;
        if (_m.checkMove() && _m.CheckGround()) return Run;
        return Idle;
    }

    private void Update()
    {
        var state = GetState();
        if (state != currentState)
        {
            _am.CrossFade(state, 0, 0);
            currentState = state;

        }
    }

    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Jump = Animator.StringToHash("Jump");

}