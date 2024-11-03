using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public ObjectPool bulletPool;
    public float fireRate = 1f;
    public float bulletSpeed = 2f;
    public int numberOfBullets = 10 ;
    public float radius = 5f;

    private float nextFireTime = 0f;
    private float offset = 0f;
    public float rotationRate = 10f;
    public float bulletAliveTime = 3f;

    void Update()
    {
        if (Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            offset += rotationRate;
            for (int i = 0; i < numberOfBullets; i++)
            {
                float angle = (i * 2 * Mathf.PI / numberOfBullets) + offset;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));
                PooledObject bullet = bulletPool.GetObject();
                bullet.gameObject.SetActive(true);
                bullet.transform.position = transform.position;
                bullet.aliveTime = bulletAliveTime;
                Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                rb.velocity = direction * bulletSpeed;
            }
        }
    }
}
