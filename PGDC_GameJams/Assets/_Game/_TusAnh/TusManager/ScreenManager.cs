using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public enum GameScreens
{
    MenuScreen,
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

public class ScreenManager : GenericSingleton<ScreenManager>
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
        SoundManager.Instance.PlayFx(FxID.Click);
        prevScreens = currentScreens;
        currentScreens = GameScreens.SettingScreen;
        gameScreens[(int)GameScreens.SettingScreen].SetActive(!gameScreens[(int)GameScreens.SettingScreen].activeSelf);
    }

    public void OpenPlayScreen()
    {
        SoundManager.Instance.PlayFx(FxID.Click);
        prevScreens = currentScreens;
        currentScreens = GameScreens.GameLoadingScreen;
        gameScreens[(int)GameScreens.GameLoadingScreen].SetActive(!gameScreens[(int)GameScreens.GameLoadingScreen].activeSelf);
        StartCoroutine(LoadNewScene(2f));

    }

    public void CreditScreen()
    {
        SoundManager.Instance.PlayFx(FxID.Click);
        prevScreens = currentScreens;
        currentScreens = GameScreens.CreditScreen;
        gameScreens[(int)GameScreens.CreditScreen].SetActive(!gameScreens[(int)GameScreens.CreditScreen].activeSelf);
    }
    
    public void BackPrevScreen()
    {
        SoundManager.Instance.PlayFx(FxID.Click);
        (prevScreens, currentScreens) = (currentScreens, prevScreens);
        gameScreens[(int)currentScreens].SetActive(true);
        gameScreens[(int)prevScreens].SetActive(false);
    }

    public void ExitButton()
    {
        SoundManager.Instance.PlayFx(FxID.Click);
        Application.Quit();
    }

    public IEnumerator LoadNewScene(float delay)
    {
        SoundManager.Instance.PlayMusic(false);
        yield return new WaitForSeconds(delay);
        SoundManager.Instance.ChangeMusic(MusicID.BattleMusic);
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(1);
        SoundManager.Instance.PlayMusic(true);
    }

}