using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class EnemyHit : DamageableBase
{
    private EnemyAttack enemyAttack;

    private void Start()
    {
        enemyAttack = GetComponent<EnemyAttack>();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.PlayerBullet))
        {
            TakeDamage(1f);
            collision.GetComponent<Projectile>().Explode();
        }
    }

    public override void Die()
    {
        foreach(Projectile bullet in enemyAttack.bullets)
        {
            bullet.Release();
        }
        Destroy(gameObject);
    }
}
