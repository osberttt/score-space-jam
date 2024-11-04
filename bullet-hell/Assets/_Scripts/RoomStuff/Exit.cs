using UnityEngine;

public class Exit : MonoBehaviour
{
    private Transform player;
    private bool isPassable;
    private SpriteRenderer sprite;
    private BoxCollider2D boxCollider;

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>().gameObject.GetComponent<Transform>();
        boxCollider = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetPassable(false);
    }

    private void Update()
    {
        if (isPassable && player.position.x > transform.position.x + 0.5f)
        {
            SetPassable(false);
		}
    }

    public void SetPassable(bool passable)
    { 
	    if (passable)
        {
            isPassable = true;
            boxCollider.enabled = false;
            sprite.color = Color.green;
        }
        else
        { 
            isPassable = false;
            boxCollider.enabled = true;
            sprite.color = Color.white;
		}
    }
}
