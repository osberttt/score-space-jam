using UnityEngine;
using System.Collections;
using Core;

public class GameplayManager : MonoBehaviour
{
    [SerializeField] PauseUI pauseUI;
    [SerializeField] InputHealthUI inputHealthUI;
    [SerializeField] GameObject loginUI;
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
        loginUI.SetActive(true);
        playerController.isControllable = false;
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

    public void RestartGame()
    {
        SceneLoader.Instance.LoadSceneWithLoadingScreen(Constants.Scenes.Main);
	}

    public void OnGameOver()
    {
        //Time.timeScale = 0;
        Debug.Log("Game Over");
        playerController.isControllable = false;
        StartCoroutine(GameOverRoutine());
	}

    public void OnPlayerLogin()
    {
        loginUI.SetActive(false);
        inputHealthUI.gameObject.SetActive(true);
	}

    IEnumerator GameOverRoutine()
    {
        int finalScore = (int)(playerHit.Health - playerHit.MaxHealth);
        gameOverUI.SetScoreValue(finalScore);
        gameOverUI.gameObject.SetActive(true);
        yield return lootLockerManager.SubmitScoreRoutine(finalScore); 
        yield return lootLockerManager.FatchTopHighscoresRoutine(); 
	}
}
