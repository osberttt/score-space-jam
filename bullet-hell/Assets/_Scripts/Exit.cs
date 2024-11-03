using UnityEngine;
using Core;

public class Exit : MonoBehaviour
{
    private BoxCollider2D boxCollider;
    [SerializeField] private Transform player;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Start()
    {
        boxCollider.enabled = false;
    }

    private void Update()
    {
        if (player.position.x > transform.position.x + 0.5f)
        { 
            boxCollider.enabled = true;
		}
    }
}
