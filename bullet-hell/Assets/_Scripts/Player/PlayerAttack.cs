using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private ObjectPool bulletPool;
    [SerializeField] public float bulletAliveTime = 3f;

    public void Fire(Vector2 aDirection)
    {
        Debug.Log("Fire");
        PooledObject bullet = bulletPool.GetObject();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = transform.position;
        bullet.aliveTime = bulletAliveTime;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = aDirection * bulletSpeed;
    }
}