using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
public class BOMB : MonoBehaviour
{
    [SerializeField] private AudioClip explosionSfx;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.Player))
        {
            AudioManager.Instance.PlaySoundFXClip(explosionSfx, transform, 60f);
            EventManager.InvokeEvent(GameplayEvent.GameOver);
        }
    }
}
