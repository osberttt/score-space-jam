using UnityEngine;
using Core;
using UnityEngine.UI;
public class ActivationZone : MonoBehaviour
{
    [SerializeField] private Image _healthBar;
    [SerializeField] private float requiredTime;
    [SerializeField] private float timer;
    [SerializeField] private bool stepOn;
    [HideInInspector] public Room room;

    [SerializeField] private AudioClip glassBreak;
    public bool isActivate;

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (stepOn && !isActivate)
        {
            timer += Time.deltaTime;
		}

        if (timer >= requiredTime && !isActivate)
        {
            stepOn = false;
            isActivate = true;
            animator.Play("AZ break");
            AudioManager.Instance.PlaySoundFXClip(glassBreak, transform, 50f);
            room.numActivatedZone += 1;
		}
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        _healthBar.fillAmount = (requiredTime - timer) / requiredTime;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.Player) && !isActivate)
        {
            stepOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.Player) && !isActivate)
        {
            stepOn = false;
        }
    }
}
