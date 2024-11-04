using UnityEngine;
using UnityEngine.UI;
using Core;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class TitleScreen : MonoBehaviour
{
    [SerializeField] GameObject settingUI;

    public void StartGame()
    {
        Debug.Log("Start Game");
        SceneLoader.Instance.LoadSceneWithLoadingScreen("Scenes/" + Constants.Scenes.Main);
        Time.timeScale = 1;
    }

    public void SettingMenu()
    {
        Debug.Log("Open Setting Menu");
        settingUI.SetActive(true);
    }

    public void ExitGame()
    {
        Debug.Log("Exit Game");
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}