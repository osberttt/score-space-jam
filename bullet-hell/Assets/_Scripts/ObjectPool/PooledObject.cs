using UnityEngine;

public abstract class PooledObject : MonoBehaviour
{
    public ObjectPool pool;
    public float aliveTime;

    public void Release()
    {
        pool.ReturnToPool(this);
	}
}
