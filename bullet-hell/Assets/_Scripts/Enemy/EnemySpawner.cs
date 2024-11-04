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
    [SerializeField] private Transform playerTransform;

    [Header("Numbers")]
    [SerializeField] private int maxEnemies; // enemy capacity of the room
    [SerializeField] private int maxEnemiesPerWave;
    [SerializeField] private int minBullets;
    [SerializeField] private int maxBullets;
    [SerializeField] private float spawnCD;

    private List<GameObject> enemies;

    // Lists
    [HideInInspector] public List<Transform> spawnPoints;

    private void Awake()
    {
        GetSpawnPoints();
        enemies = new List<GameObject>();
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

    private bool isSpawning;
    public void SpawnEnemies()
    {
        isSpawning = true;
        SpawnEnemyGroup(maxEnemies);
        StartCoroutine(SpawnEnemiesCo());
    }

    public void StopSpawningEnemies()
    {
        isSpawning = false;
    }
    IEnumerator SpawnEnemiesCo()
    {
        while (isSpawning)
        {
            yield return new WaitForSeconds(spawnCD);

            // For random number of enemies per wave
            int numberOfEnemies = Util.GetRandomNumberRange(1, maxEnemiesPerWave);
            if (_enemyParent.transform.childCount < maxEnemies) SpawnEnemyGroup(numberOfEnemies);

            // For one enemy per wave
            //Transform spawnPos = Util.GetRandomElementFromList(spawnPoints);
            //if (_enemyParent.transform.childCount < maxEnemies) SpawnAnEnemy(spawnPos);           
        }
    }

    private void SpawnEnemyGroup(int numberOfEnemies)
    {
        List<Transform> SpawnPosGroup = Util.GetRandomElementsFromList(spawnPoints, numberOfEnemies);
        foreach(Transform spawnPos in SpawnPosGroup)
        {
            SpawnAnEnemy(spawnPos);
        }
    }

    private void SpawnAnEnemy(Transform spawnPos)
    {       
        GameObject instance = Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
        instance.transform.parent = _enemyParent;

        EnemyAttack enemyAttack = instance.GetComponent<EnemyAttack>();
        enemyAttack.bulletPool = bulletPool;
        enemyAttack.numberOfBullets = Util.GetRandomNumberRange(minBullets, maxBullets);

        EnemyController enemyController = instance.GetComponent<EnemyController>();
        enemyController.playerTransform = playerTransform;

        enemies.Add(instance);
    }

    public void ClearEnemies()
    {
        foreach(GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        enemies.Clear();
    }
}
