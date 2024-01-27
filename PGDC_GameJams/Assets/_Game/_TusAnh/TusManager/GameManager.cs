using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameStates
{
    Play,
    Pause,
}
public class GameManager : GenericSingleton<GameManager>
{
    [SerializeField] private InputAction ecsAction;
    private GameStates currentStates = GameStates.Pause;

    private void OnEnable()
    {
        ecsAction.Enable();
    }

    private void OnDisable()
    {
        ecsAction.Disable();
    }

    private void Start()
    {
        ecsAction.performed += ToggleGameState;
    }
    

    private void Update()
    {
        StateSwitcher();
    }

    private void StateSwitcher()
    {
        switch (currentStates)
        {
            case GameStates.Pause:
                break;
            case GameStates.Play:
                break;
            default:
                break;
        }
        
    }
    private void ToggleGameState(InputAction.CallbackContext context)
    {
            currentStates = currentStates == GameStates.Pause ? GameStates.Play : GameStates.Pause;
    }
  
}
