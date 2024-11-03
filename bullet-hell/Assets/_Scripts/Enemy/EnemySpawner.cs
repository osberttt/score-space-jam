using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [Header("Game Objects")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform _spawnPointsParent;
    [SerializeField] private Transform _enemyParent;
    [SerializeField] private ObjectPool bulletPool;

    [Header("Numbers")]
    [SerializeField] private int maxEnemies;
    [SerializeField] private int minBullets;
    [SerializeField] private int maxBullets;
    [SerializeField] private float spawnCD;

    // Lists
    [HideInInspector] public List<Transform> spawnPoints;

    private void Awake()
    {
        GetSpawnPoints();      
    }

    private void GetSpawnPoints()
    {
        Transform[] children = _spawnPointsParent.GetComponentsInChildren<Transform>(true);
        foreach (Transform child in children)
        {
            // exclude parent transform
            if (child != _spawnPointsParent.transform)
            {
                spawnPoints.Add(child);
            }
        }
    }

    public void SpawnEnemies()
    {
        StartCoroutine(SpawnEnemiesCo());
    }

    IEnumerator SpawnEnemiesCo()
    {
        while (true)
        {
            if (_enemyParent.transform.childCount < maxEnemies) SpawnAnEnemy();           
            yield return new WaitForSeconds(spawnCD);
        }
    }
    private void SpawnAnEnemy()
    {
        Transform spawnPos = Util.GetRandomElementFromList(spawnPoints);
        GameObject instance = Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
        instance.transform.parent = _enemyParent;

        Enemy enemy = instance.GetComponent<Enemy>();
        enemy.bulletPool = bulletPool;
        enemy.numberOfBullets = Util.GetRandomNumberRange(minBullets, maxBullets);

    }
}
