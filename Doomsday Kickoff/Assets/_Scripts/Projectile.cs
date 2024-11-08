using System.Collections.Generic;
using UnityEngine;

public class Projectile : PooledObject 
{
    private void Update()
    {
        aliveTime -= Time.deltaTime;
        if (aliveTime < 0f) Explode();
    }

    public void Explode()
    {
        // Play bullet explosion animation
        Release();
    }
}
