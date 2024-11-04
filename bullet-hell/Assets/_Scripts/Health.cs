using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
using System;

public class Health : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.Player))
        {
            collision.GetComponent<PlayerHit>().RestoreHealth(1f);
            DestroySelf();
        }
    }

    private void DestroySelf()
    {
        Destroy(gameObject);
    }
}
