using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Action<Enemy> OnEndReached;
    private EnemyHealth _enemyHealth;
    private SpriteRenderer _spriteRenderer;

    [SerializeField] private float moveSpeed = 3f;

    public float MoveSpeed { get; set; }
    public Waypoint Waypoint { get; set; }

    private int currentWaypointIndex ;
    private Vector3 LastPointPosition;
    public Vector3 CurrentPointPosition => Waypoint.GetWaypointPosition(currentWaypointIndex);

    private void Start()
    {
        currentWaypointIndex = 0;
        MoveSpeed = moveSpeed;
        _enemyHealth = GetComponent<EnemyHealth>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        LastPointPosition = transform.position;
    }


    private void Update()
    {
        Move();
        Rotate();
        if (currentPositionReached()) UpdateCurrentPointIndex();
    }
    private void Move()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition,MoveSpeed* Time.deltaTime);
    }

    private void Rotate()
    {
        if(CurrentPointPosition.x > LastPointPosition.x)
        {
            _spriteRenderer.flipX = false;
        }else
        {
            _spriteRenderer.flipX = true;
        }
    }
    public void StopMoving()
    {
        MoveSpeed = 0f;
    }
    public void ResumeMoving()
    {
        MoveSpeed = moveSpeed;
    }
    private bool currentPositionReached()
    {
        float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;
        if (distanceToNextPointPosition < 0.1)
        {
            LastPointPosition = transform.position;
            return true;
        }
        else return false;
        
      
    }
    private void UpdateCurrentPointIndex()
    {
        int lastWaypointIndex = Waypoint.Points.Length-1;
        if (currentWaypointIndex < lastWaypointIndex) currentWaypointIndex++;
        else EndPointReached();
    }

    private void EndPointReached()
    {
        OnEndReached?.Invoke(this);
        _enemyHealth.ResetHealth();
        ObjectPooler.ReturnToPool(gameObject);
    }
 
    public void ResetEnemy()
    {
        currentWaypointIndex = 0;
    }
}
