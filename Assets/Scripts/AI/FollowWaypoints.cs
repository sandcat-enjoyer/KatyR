using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowWaypoints : MonoBehaviour
{
    public List<Transform> waypoints;
    public NavMeshAgent AIObject;
    public PlayerMovement playerMovement;
    public Animator AIanimator;
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 4f;
    private float movementSpeed = 5f;
    private int lastWaypointIndex;
    private bool waypointTriggered;

    private void Start()
    {
        targetWaypoint = waypoints[targetWaypointIndex];
        lastWaypointIndex = waypoints.Count - 1;
    }

    void Update()
    {
        float movementStep = movementSpeed * Time.deltaTime;
        // calculate distance to waypoint
        float distance = Vector3.Distance(transform.position, targetWaypoint.position);
        print(distance);
        
        // direction from katy to AI
        AIObject.speed = playerMovement.realSpeed;
        AIObject.acceleration = playerMovement.realSpeed;
        if (AIObject.velocity.magnitude > 0.2f)
        {
            AIanimator.speed = AIObject.velocity.magnitude / 3;
            AIanimator.SetBool("isRunning", true);
        }

        else
        {
            AIanimator.speed = 1f;
            AIanimator.SetBool("isRunning", false);
        }


        CheckDistanceToWaypoint(distance);
        AIObject.SetDestination(targetWaypoint.position);
        Vector3 playerRotation = transform.rotation.eulerAngles;
        playerRotation.x = 0;
        playerRotation.z = 0;
        transform.rotation = Quaternion.Euler(playerRotation);
        
        
    }

    void CheckDistanceToWaypoint(float currentDistance)
    {
        if (currentDistance <= minDistance)
        {
            
            print("target index: " + targetWaypointIndex);
            waypoints[targetWaypointIndex].gameObject.SetActive(false);
            targetWaypointIndex++;
            UpdateTargetWaypoint();
        }
    }

    void UpdateTargetWaypoint()
    {
        if (targetWaypointIndex > lastWaypointIndex)
        {
            targetWaypointIndex = 0;
        }
        targetWaypoint = waypoints[targetWaypointIndex];
    }
}
