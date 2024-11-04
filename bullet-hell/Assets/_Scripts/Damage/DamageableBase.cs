using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageableBase : MonoBehaviour,IDamageable
{
    [SerializeField] private Image _healthBar;
    // hit animation
    private SpriteRenderer spriteRenderer;
    [SerializeField] private float hitDuration = 0.2f;
    private Color originalColor;
    private float hitTimer;

    // hp
    [SerializeField] private float _maxHealth = 1f;
    private float _currentHealth;
    public float MaxHealth { get => _maxHealth; set => _maxHealth = value; }
    public float Health { get => _currentHealth; set => _currentHealth = value; }

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        _currentHealth = _maxHealth;
    }

    public virtual void Die()
    {
        Destroy(gameObject);
    }

    public virtual void TakeDamage(float damageAmount)
    {
        Hit();
        _currentHealth -= damageAmount;
        if (_currentHealth <= 0) Die();
        else UpdateHealthBar();
    }

    public void RestoreHealth(float health)
    {
        if (_currentHealth + health > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
        else
        {
            _currentHealth += health;
        }

        UpdateHealthBar();
    }

    public void UpdateHealthBar()
    {
        _healthBar.fillAmount = _currentHealth / _maxHealth;
    }

    private void Update()
    {
        if (hitTimer > 0)
        {
            hitTimer -= Time.deltaTime;
            if (hitTimer <= 0)
            {
                spriteRenderer.color = originalColor;
            }
        }
    }

    public void Hit()
    {
        spriteRenderer.color = Color.red;
        hitTimer = hitDuration;
    }
}
