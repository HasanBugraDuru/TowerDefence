using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float AttackRange = 3f;
    [SerializeField] private bool  Rotatable = true;

    public Enemy CurrentTargetEnemy { get; set; }

    private bool _gamestarted;
    private List<Enemy> enemies;

    private void Start()
    {
        _gamestarted = true;
        enemies = new List<Enemy>();  
    }
    private void Update()
    {
        GetCurrentEnemyTarget();
        RotateTowardsTarget();
    }

    private void RotateTowardsTarget()
    {
        if(CurrentTargetEnemy==null) return;
        Vector3 targetPosition = CurrentTargetEnemy.transform.position-transform.position;
        float angle = Vector3.SignedAngle(transform.up, targetPosition, transform.forward);
        if(Rotatable) transform.Rotate(0f,0f,angle);
    }
    private void GetCurrentEnemyTarget()
    {
        if(enemies.Count <= 0)
        {
            CurrentTargetEnemy = null;
            return;
        }
        else
        {
            CurrentTargetEnemy = enemies[0];
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy newEnemy = other.GetComponent<Enemy>();
            enemies.Add(newEnemy);
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Enemy enemy = other.GetComponent<Enemy>();
            if (enemies.Contains(enemy))
            {
                enemies.Remove(enemy);
            }
        }   
    }
    private void OnDrawGizmos()
    {
        if (!_gamestarted)
        {
            GetComponent<CircleCollider2D>().radius = AttackRange;
        }
        Gizmos.DrawWireSphere(transform.position, AttackRange);
    }
}
