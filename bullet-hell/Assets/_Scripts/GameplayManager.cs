using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] PauseUI pauseUI;
    public static bool isGamePaused;

    private void OnEnable()
    {
        EventManager.RegisterToEvent(GameplayEvent.PauseGame, OnPauseGame);       
        EventManager.RegisterToEvent(GameplayEvent.ResumeGame, OnResumeGame);       
    }

    private void OnDisable()
    {
        EventManager.UnregisterFromEvent(GameplayEvent.PauseGame, OnPauseGame);       
        EventManager.UnregisterFromEvent(GameplayEvent.ResumeGame, OnResumeGame);       
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Press P");
            if (isGamePaused)
            {
                EventManager.InvokeEvent(GameplayEvent.ResumeGame);
            }
            else
            { 
                EventManager.InvokeEvent(GameplayEvent.PauseGame);
			}
        }
    }

    private void OnPauseGame()
    {
        pauseUI.gameObject.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0;
	}

    private void OnResumeGame()
    {
        pauseUI.gameObject.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1;
	}
}
