using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class Room : MonoBehaviour
{
    private EnemySpawner _enemySpawner;

    private void Awake()
    {
        _enemySpawner = GetComponent<EnemySpawner>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.Player))
        {
            _enemySpawner.SpawnEnemies();
        }
    }
}
