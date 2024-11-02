using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private TestEnemy enemyPrefab; 

    public void Spawn(Vector2 spawnPos) 
	{
		TestEnemy instance = Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
		instance.Initialize();
		instance.gameObject.SetActive(true);
	}
}
