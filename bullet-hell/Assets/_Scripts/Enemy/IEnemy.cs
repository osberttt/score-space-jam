using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy 
{
    public string EnemyName { get; set; }
    public float MoveSpeed { get; set; }
    public float Damage { get; set; }

    public void Initialize();
}
