using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;
public class Wall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.PlayerBullet) || collision.CompareTag(Constants.Tags.EnemyBullet))
        {
            collision.GetComponent<Projectile>().Explode();
        }
    }
}
