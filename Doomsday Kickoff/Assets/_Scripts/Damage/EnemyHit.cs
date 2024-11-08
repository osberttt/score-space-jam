using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class EnemyHit : DamageableBase
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.PlayerBullet))
        {
            TakeDamage(1f);
            collision.GetComponent<Projectile>().Release();
        }
    }
}
