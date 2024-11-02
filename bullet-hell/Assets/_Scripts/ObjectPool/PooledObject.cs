using UnityEngine;

public class PooledObject : MonoBehaviour
{
    public ObjectPool pool;
    public float aliveTime;
    public void Release()
    {
        pool.ReturnToPool(this);
	}

    private void Update()
    {
        aliveTime -= Time.deltaTime;
        if (aliveTime < 0f) Release();
    }
}
