using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System;

public class Health : MonoBehaviour
{
    [SerializeField] private AudioClip explosionSfx;
    [SerializeField] private ParticleSystem explosion;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.Player))
        {
            AudioManager.Instance.PlaySoundFXClip(explosionSfx, transform, 60f);
            Instantiate(explosion, transform.position, Quaternion.identity);
            collision.GetComponent<PlayerHit>().RestoreHealth(1f);
            Destroy(gameObject);
        }
    }
}
