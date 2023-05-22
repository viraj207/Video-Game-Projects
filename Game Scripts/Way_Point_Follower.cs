using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Way_Point_Follower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypoint = 0;

    [SerializeField] private float speed = 2;

    private void Update()
    {   //Checking to see if the game object is touching the waypoint.
        if (Vector2.Distance(waypoints[currentWaypoint].transform.position,transform.position) < .1f)
        {
            currentWaypoint = currentWaypoint + 1;
            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }

        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
    }
}
