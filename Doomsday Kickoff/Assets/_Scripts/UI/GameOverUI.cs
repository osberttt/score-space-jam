using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text yourScoreValue;
    [SerializeField] private Button RestartButton;

    public void SetScoreValue(int aScore)
    {
        yourScoreValue.text = aScore.ToString();
	}
}
