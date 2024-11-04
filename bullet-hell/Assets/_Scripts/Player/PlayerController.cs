using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer), typeof(Animator))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float fireCooldown;
    private float fireCooldownTimer;
    private Vector2 direction;
    private Vector2 mousePos;

    private Rigidbody2D body;
    private SpriteRenderer sprite;
    private Animator anim;
    private PlayerAttack playerAttack;
    public bool isControllable;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerAttack = GetComponent<PlayerAttack>();

        body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }


    private void Update()
    {
        if (isControllable)
        {
            direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
            body.velocity = direction * moveSpeed;

            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            fireCooldownTimer += Time.deltaTime;

            HandleFlip();
            HandleMoveAnim();
            HandleAttack();
        }
    }

    private void HandleAttack()
    {
        if (Input.GetMouseButtonDown(0) && fireCooldownTimer >= fireCooldown)
        {
            Vector2 fireDir = (mousePos - (Vector2)transform.position).normalized;
            playerAttack.Fire(fireDir);
            fireCooldownTimer = 0;
        }
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
			}
            else if (direction.y < 0)
            {
                anim.Play("RunSE");
			}
            else 
			{
                anim.Play("RunE");
            }
        }
        else 
		{ 
		    if (direction.y > 0)
            {
                anim.Play("RunN");
			}
            else if (direction.y < 0)
            {
                anim.Play("RunS");
			}

		}
    }
}
