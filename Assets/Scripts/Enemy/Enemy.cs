using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static Action OnEndReached;

    [SerializeField] private float moveSpeed = 3f;

    public Waypoint Waypoint { get; set; }

    private int currentWaypointIndex ;
    public Vector3 CurrentPointPosition => Waypoint.GetWaypointPosition(currentWaypointIndex);

    private void Update()
    {
        Move();
        if (currentPositionReached()) UpdateCurrentPointIndex();
    }
    private void Move()
    {
        
        transform.position = Vector3.MoveTowards(transform.position, CurrentPointPosition,moveSpeed* Time.deltaTime);
    }
    private bool currentPositionReached()
    {
        float distanceToNextPointPosition = (transform.position - CurrentPointPosition).magnitude;
        if (distanceToNextPointPosition < 0.1) return true;
        else return false;
        
      
    }
    private void UpdateCurrentPointIndex()
    {
        int lastWaypointIndex = Waypoint.Points.Length-1;
        if (currentWaypointIndex < lastWaypointIndex) currentWaypointIndex++;
        else
        {
            ReturnEnemyToPool();
        }
    }

    private void ReturnEnemyToPool()
    {
        OnEndReached?.Invoke();
        ObjectPooler.ReturnToPool(gameObject);
    }
    private void Start()
    {
       currentWaypointIndex = 0 ;
    }

}
