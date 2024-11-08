using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class PlayerHit : DamageableBase
{
    public int initialHealth;
    public override void Die()
    {
        // Don't wanna distroy player 
        EventManager.InvokeEvent(GameplayEvent.GameOver);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.EnemyBullet))
        {
            TakeDamage(1f);
            collision.GetComponent<Projectile>().Explode();
        }
    }

}
