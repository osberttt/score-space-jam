using UnityEngine;
using System.Collections;

public class GameplayManager : MonoBehaviour
{
    // GameplayManager take the charge in invoking Events

    [SerializeField] PauseUI pauseUI;
    [SerializeField] InputHealthUI inputHealthUI;
    [SerializeField] PlayerHit playerHit; // for health
    [SerializeField] PlayerController playerController; // for health
    public static bool isGamePaused;
    public LootLockerManager lootLockerManager;

    private void OnEnable()
    {
        EventManager.RegisterToEvent(GameplayEvent.GameOver, OnGameOver);       
    }

    private void OnDisable()
    {
        EventManager.UnregisterFromEvent(GameplayEvent.GameOver, OnGameOver);       
    }

    private void Start()
    {
        playerController.isControllable = false;
        inputHealthUI.gameObject.SetActive(true);
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

    public void SetupInitHealth()
    {
        playerHit.Health = inputHealthUI.inputHealth;
        playerHit.UpdateHealthBar();
        inputHealthUI.gameObject.SetActive(false);
        playerController.isControllable = true;
        Debug.Log("Set initial health to " + inputHealthUI.inputHealth);
        Time.timeScale = 1;
	}

    public void OnGameOver()
    {
        //Time.timeScale = 0;
        Debug.Log("Game Over");
        playerController.isControllable = false;
        StartCoroutine(GameOverRoutine());
	}

    IEnumerator GameOverRoutine()
    {
        int finalScore = (int)(playerHit.Health - playerHit.MaxHealth);
        Debug.Log("Try to submit score: " + finalScore.ToString());
        yield return lootLockerManager.SubmitScoreRoutine(finalScore); 
	}
}
