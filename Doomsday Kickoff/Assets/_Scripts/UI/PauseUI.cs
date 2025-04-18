using UnityEngine;
using UnityEngine.UI;
using Core;

public class PauseUI : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button settingButton;
    [SerializeField] Button menuButton;

    [SerializeField] GameObject SettingUI;

    private void OnDisable()
    {
        SettingUI.SetActive(false);       
    }

    public void SettingMenu()
    {
        SettingUI.SetActive(true);
    }

    public void GoToMenu()
    {
        Debug.Log("Go To Menu");
        SceneLoader.Instance.LoadSceneWithoutLoadingScreen(Constants.Scenes.MainMenu);
    }
}