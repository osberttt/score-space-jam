using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputHealthUI : MonoBehaviour
{
    [SerializeField] private Slider inputHealthSlider;
    [SerializeField] private TMP_Text healthValueText;
    [SerializeField] private Button startButton;
    [SerializeField] private PlayerHit playerHit;
    [HideInInspector] public int inputHealth; 

    private void Start()
    {
        inputHealthSlider.maxValue = (int)playerHit.MaxHealth;
        inputHealthSlider.value = (int)playerHit.MaxHealth;
        inputHealth = (int)inputHealthSlider.value;
    }

    private void Update()
    {
        inputHealth = (int)inputHealthSlider.value;
        healthValueText.text = inputHealth.ToString() + " / " + ((int)playerHit.MaxHealth).ToString();
        playerHit.UpdateHealthBar();

        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            Debug.Log("Press enter");
            startButton.onClick.Invoke();	
		}
    }
}
