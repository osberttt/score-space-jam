using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    [SerializeField] private float initPoolSize = 30;
    [SerializeField] PooledObject pooledObject;
    private Stack<PooledObject> stack;

    private void Awake()
    {
        SetupPool();
    }

    private void SetupPool()
    {
        stack = new Stack<PooledObject>();
        PooledObject instance = null;
        for (int i=0; i<initPoolSize; i++)
        {
            instance = Instantiate(pooledObject);
            instance.gameObject.SetActive(false);
            instance.transform.parent = transform;
            instance.pool = this;
            stack.Push(instance);
		}
	}

    public PooledObject GetObject()
    { 
	    if (stack.Count == 0)
        {
            PooledObject newObject = Instantiate(pooledObject);
            newObject.gameObject.SetActive(false);
            newObject.pool = this;
            return newObject;
        }

        PooledObject instance = stack.Pop();
        return instance;
    }

    public void ReturnToPool(PooledObject anObject)
    {
        if (!stack.Contains(anObject))
        {
            anObject.gameObject.SetActive(false);
            stack.Push(anObject);
        }
    }
}
