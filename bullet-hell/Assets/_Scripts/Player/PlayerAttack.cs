using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    [SerializeField] private ObjectPool bulletPool;
    [SerializeField] private float bulletAliveTime = 3f;
    [SerializeField] private float firePosOffset = 1f;

    public void Fire(Vector2 aDirection)
    {
        PooledObject bullet = bulletPool.GetObject();
        bullet.gameObject.SetActive(true);
        bullet.transform.position = (Vector2)transform.position + aDirection * firePosOffset;
        bullet.aliveTime = bulletAliveTime;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.velocity = aDirection * bulletSpeed;
    }
}