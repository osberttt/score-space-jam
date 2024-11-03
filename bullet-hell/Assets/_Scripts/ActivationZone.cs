using UnityEngine;
using Core;

public class ActivationZone : MonoBehaviour
{
    [SerializeField] private float requiredTime = 5f;
    [SerializeField] private float timer;
    [SerializeField] private bool stepOn;

    private void Update()
    {
        if (stepOn)
        {
            timer += Time.deltaTime;
		}

        if (timer >= requiredTime)
        {
            stepOn = false;
            Debug.Log("Activate");
		}
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.Player) && timer < requiredTime)
        {
            stepOn = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.Player) && timer < requiredTime)
        {
            stepOn = false;
        }
    }
}
