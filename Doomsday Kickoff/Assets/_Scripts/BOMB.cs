using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
public class BOMB : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private ParticleSystem explosion;
    [SerializeField] private AudioClip explosionSfx;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.Player))
        {
            AudioManager.Instance.PlaySoundFXClip(explosionSfx, transform, 60f);
            sr.enabled = false;
            Instantiate(explosion, transform.position, Quaternion.identity);
            StartCoroutine(BombCo());
        }
    }

    IEnumerator BombCo()
    {
        yield return new WaitForSeconds(2f);
        EventManager.InvokeEvent(GameplayEvent.GameOver);
    }
}
