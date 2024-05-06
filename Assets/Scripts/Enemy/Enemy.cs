using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private Waypoint waypoint;

    private int currentWaypointIndex ;
    public Vector3 CurrentPointPosition => waypoint.GetWaypointPosition(currentWaypointIndex);

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
        int lastWaypointIndex = waypoint.Points.Length-1;
        if (currentWaypointIndex < lastWaypointIndex) currentWaypointIndex++;
    }
    private void Start()
    {
        currentWaypointIndex = 0 ;
    }

}
