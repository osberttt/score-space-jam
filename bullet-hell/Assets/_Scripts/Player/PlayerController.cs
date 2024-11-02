using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Vector2 direction;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        body.velocity = direction * moveSpeed;

        HandleFlip();
    }

    private void HandleFlip()
    { 
        if (direction.x < 0 && !sprite.flipX)
        {
            sprite.flipX = true;
		}
        else if (direction.x > 0 && sprite.flipX)
        {
            sprite.flipX = false;
		}
	}
}
