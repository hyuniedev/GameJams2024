using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameScreens
{
    MenuScreen,
    GamePlayScreen,
    SettingScreen,
    CreditScreen,
    GameLoadingScreen,
    MapSelecting,
    PlayerSelecting,
    EndGame
}

public enum GameScenes
{
    TitleScene,
    GamePlay,
}

public enum UIButtons
{
    PlayBtn,
    SettingBtn,
    ExitBtn,
    CreditBtn
}

public class SceneManager : GenericSingleton<SceneManager>
{
    public List<GameObject> gameScreens;
    public List<Button> buttons;

    private GameScreens currentScreens;
    private GameScreens prevScreens;
    
    private void Start()
    {
        currentScreens = GameScreens.MenuScreen;
        prevScreens = GameScreens.MenuScreen;
        gameScreens[(int)currentScreens].SetActive(!gameScreens[(int)currentScreens].activeSelf);
    }

    // private void Update()
    // {
    //     Debug.Log(prevScreens +" "+ currentScreens);
    // }

    public void OpenSettingScreen()
    {
        prevScreens = currentScreens;
        currentScreens = GameScreens.SettingScreen;
        gameScreens[(int)GameScreens.SettingScreen].SetActive(!gameScreens[(int)GameScreens.SettingScreen].activeSelf);
    }

    public void OpenPlayScreen()
    {
        prevScreens = currentScreens;
        currentScreens = GameScreens.GamePlayScreen;
        gameScreens[(int)GameScreens.GamePlayScreen].SetActive(!gameScreens[(int)GameScreens.GamePlayScreen].activeSelf);
    }

    public void CreditScreen()
    {
        prevScreens = currentScreens;
        currentScreens = GameScreens.CreditScreen;
        gameScreens[(int)GameScreens.CreditScreen].SetActive(!gameScreens[(int)GameScreens.CreditScreen].activeSelf);
    }
    
    public void BackPrevScreen()
    {
        (prevScreens, currentScreens) = (currentScreens, prevScreens);
        gameScreens[(int)currentScreens].SetActive(true);
        gameScreens[(int)prevScreens].SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}