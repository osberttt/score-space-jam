using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Core;

public class Room : MonoBehaviour
{
    private EnemySpawner _enemySpawner;
    public int numActivatedZone;
    [SerializeField] private List<ActivationZone> activationZones;
    [SerializeField] private Exit exit;
    

    private void Awake()
    {
        _enemySpawner = GetComponent<EnemySpawner>();
    }

    private void Start()
    {
        SetupActivationZones();
    }

    private void Update()
    {
        if (numActivatedZone == activationZones.Count)
        {
            exit.SetPassable(true);
		}
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Constants.Tags.Player) && _enemySpawner)
        {
            _enemySpawner.SpawnEnemies();
        }
    }

    private void SetupActivationZones()
    { 
        foreach(ActivationZone zone in activationZones)
        {
            zone.room = this;
		}
	}
}
