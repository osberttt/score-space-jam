using UnityEngine;

public class TestEnemy : MonoBehaviour, IEnemy 
{
    [SerializeField] private string enemyName;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float damage;
    public string EnemyName { get => enemyName; set => enemyName = value; }
    public float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }
    public float Damage { get => damage; set => damage = value; }


    public void Initialize()
    {
        // can do something when initailize
    }
}
