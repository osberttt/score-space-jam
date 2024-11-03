using UnityEngine;

public class Projectile : PooledObject 
{
    [SerializeField] private string targetTag;

    private void Update()
    {
        aliveTime -= Time.deltaTime;
        if (aliveTime < 0f) Release();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            Release();
		}
    }
}
