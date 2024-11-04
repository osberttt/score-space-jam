using UnityEngine;
using Core;

public class ActivationZone : MonoBehaviour
{
    [SerializeField] private float requiredTime;
    [SerializeField] private float timer;
    [SerializeField] private bool stepOn;
    [HideInInspector] public Room room;
    public bool isActivate;

    private SpriteRenderer sprite;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
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
            sprite.color = Color.green;
            room.numActivatedZone += 1;
            Debug.Log("Activate");
		}
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
