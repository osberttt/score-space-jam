using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    private Vector2 direction;

    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Animator anim;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        body.bodyType = RigidbodyType2D.Kinematic;
        body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }


    private void Update()
    {
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        body.velocity = direction * moveSpeed;

        HandleFlip();
        HandleMoveAnim();
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

    private void HandleMoveAnim()
    {
        if (Mathf.Abs(direction.x) > 0)
        {
            if (direction.y > 0)
            {
                anim.Play("RunNE");
                Debug.Log("NE");
			}
            else if (direction.y < 0)
            {
                anim.Play("RunSE");
                Debug.Log("SE");
			}
            else 
			{
                anim.Play("RunE");
                Debug.Log("E");
            }
        }
        else 
		{ 
		    if (direction.y > 0)
            {
                anim.Play("RunN");
                Debug.Log("N");
			}
            else if (direction.y < 0)
            {
                anim.Play("RunS");
                Debug.Log("S");
			}
            else
            {
                anim.Play("Idle");   
                Debug.Log("Idle");
			}
		}


    }
}
