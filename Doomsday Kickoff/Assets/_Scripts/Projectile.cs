using System.Collections.Generic;
using UnityEngine;

public class Projectile : PooledObject 
{
    [SerializeField] private ParticleSystem bulletHitParticles;
    private void Update()
    {
        aliveTime -= Time.deltaTime;
        if (aliveTime < 0f) Release();
    }

    public void Explode()
    {
        // Play bullet explosion animation
        Instantiate(bulletHitParticles, transform.position, Quaternion.identity);
        Release();
    }
}
