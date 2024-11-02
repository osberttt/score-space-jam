using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform _spawnPointsParent;
    [SerializeField] private Transform _enemyParent;
    public List<Transform> spawnPoints;
    [SerializeField] private float spawnCD = 1f;

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
            Transform spawnPos = Util.GetRandomElementFromList(spawnPoints);
            GameObject instance = Instantiate(enemyPrefab, spawnPos.position, Quaternion.identity);
            instance.transform.parent = _enemyParent;
            yield return new WaitForSeconds(spawnCD);
        }
    }
}
