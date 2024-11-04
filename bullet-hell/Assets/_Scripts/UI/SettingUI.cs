using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingUI : MonoBehaviour
{
    [SerializeField] private Scrollbar BGMScrollBar;
    [SerializeField] private TMP_Text BGMValueText;

    [SerializeField] private Scrollbar SFXScrollBar;
    [SerializeField] private TMP_Text SFXValueText;

    private void Start()
    {
        BGMScrollBar.value = AudioManager.Instance.GetMusicVolume();
        SFXScrollBar.value = AudioManager.Instance.GetMusicVolume();
    }

    private void OnEnable()
    {
        SelectionArrow.isControllable = false;
    }

    private void OnDisable()
    {
        SelectionArrow.isControllable = true;
    }

    private void Update()
    {
        AudioManager.Instance.SetSfxVolume(SFXScrollBar.value);
        SFXValueText.text = (int)(SFXScrollBar.value * 100) + " / 100";

        AudioManager.Instance.SetMusicVolume(BGMScrollBar.value);
        BGMValueText.text = (int)(BGMScrollBar.value * 100) + " / 100";

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Ese");
            gameObject.SetActive(false);
        }
    }
}