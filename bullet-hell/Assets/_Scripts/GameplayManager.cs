using UnityEngine;

public class GameplayManager : MonoBehaviour
{
    // GameplayManager take the charge in invoking Events

    [SerializeField] PauseUI pauseUI;
    [SerializeField] PlayerHit playerHit; // for health
    public static bool isGamePaused;

    private void OnEnable()
    {
        //EventManager.RegisterToEvent(GameplayEvent.GameOver, OnGameOver);       
    }

    private void OnDisable()
    {
        //EventManager.UnregisterFromEvent(GameplayEvent.GameOver, OnGameOver);       
    }

    private void Update()
    {
        HandlePauseGame();
    }

    private void HandlePauseGame()
    { 
        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log("Press P");
            if (!isGamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
			}
        }
	}

    public void PauseGame()
    {
        EventManager.InvokeEvent(GameplayEvent.PauseGame);
        pauseUI.gameObject.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0;
	}

    public void ResumeGame()
    {
        EventManager.InvokeEvent(GameplayEvent.ResumeGame);
        pauseUI.gameObject.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1;
	}

    public void InputInitHealth(int aValue)
    {
        playerHit.MaxHealth = aValue;
	}

    public void GameOver()
    {
        EventManager.InvokeEvent(GameplayEvent.GameOver);
	}
}
