using UnityEngine;
using System.Collections;
using Core;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] PauseUI pauseUI;
    [SerializeField] InputHealthUI inputHealthUI;
    [SerializeField] LoginUI loginUI;
    [SerializeField] GameOverUI gameOverUI;
    [SerializeField] PlayerHit playerHit; // for health
    [SerializeField] PlayerController playerController; // for health
    public static bool isGamePaused;
    public LootLockerManager lootLockerManager;

    private void OnEnable()
    {
        EventManager.RegisterToEvent(GameplayEvent.GameOver, OnGameOver);       
        EventManager.RegisterToEvent(GameplayEvent.PlayerLogin, OnPlayerLogin);       
    }

    private void OnDisable()
    {
        EventManager.UnregisterFromEvent(GameplayEvent.GameOver, OnGameOver);       
        EventManager.UnregisterFromEvent(GameplayEvent.PlayerLogin, OnPlayerLogin);       
    }

    private void Start()
    {
        Debug.Log("Player logged in before: " + LoginRecorder.isPlayerLoggedIn);
        if (!LoginRecorder.isPlayerLoggedIn)
        {
            loginUI.gameObject.SetActive(true);
        }
        else 
		{ 
            inputHealthUI.gameObject.SetActive(true);
		}
        playerController.isControllable = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        HandlePauseGame();
    }

    private void HandlePauseGame()
    { 
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Press Esc");
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
        playerHit.initialHealth = inputHealthUI.inputHealth;
        playerHit.UpdateHealthBar();
        inputHealthUI.gameObject.SetActive(false);
        playerController.isControllable = true;
        Debug.Log("Set initial health to " + inputHealthUI.inputHealth);
        Time.timeScale = 1;
	}

    public void RestartGame()
    {
        SceneLoader.Instance.LoadSceneWithoutLoadingScreen(Constants.Scenes.Main);
	}

    public void OnGameOver()
    {
        //Time.timeScale = 0;
        Debug.Log("Game Over");
        playerController.isControllable = false;
        Time.timeScale = 0;
        StartCoroutine(GameOverRoutine());
	}

    public void OnPlayerLogin()
    {
        loginUI.gameObject.SetActive(false);
        LoginRecorder.isPlayerLoggedIn = true;
        inputHealthUI.gameObject.SetActive(true);
        lootLockerManager.SetPlayerName();
	}

    IEnumerator GameOverRoutine()
    {
        int finalScore = ((int)(playerHit.Health - playerHit.initialHealth));
        if (finalScore < 0) finalScore = 0;

        gameOverUI.SetScoreValue(finalScore);
        gameOverUI.gameObject.SetActive(true);
        yield return lootLockerManager.SubmitScoreRoutine(finalScore); 
        yield return lootLockerManager.FatchTopHighscoresRoutine(); 
	}
}
