using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 3f;

    public float wanderRadius = 2f;
    public float wanderDuration = 5f;

    [HideInInspector] public Transform playerTransform;
    private Vector3 wanderTarget;
    private float wanderTimer;

    private void Start()
    {
        wanderTarget = transform.position + Random.insideUnitSphere * wanderRadius;
        wanderTimer = wanderDuration;
    }

    private void Update()
    {
        if (wanderTimer > 0)
        {
            MoveTowardsPlayer();
            wanderTimer -= Time.deltaTime;
        }
        else
        {
            MoveTowardsPlayer();
        }

    }

    private void MoveTowardsPlayer()
    {
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

    }

    private void Wander()
    {
        if (Vector3.Distance(transform.position, wanderTarget) < 0.1f)
        {
            wanderTarget = transform.position + Random.insideUnitSphere * wanderRadius;
            wanderTimer = wanderDuration;
        }

        Vector3 direction = (wanderTarget - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;
    }
}
