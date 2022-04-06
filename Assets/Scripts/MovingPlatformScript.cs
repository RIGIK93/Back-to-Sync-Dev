using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatformScript : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    [SerializeField] private GameObject waypointPath;
    List<Vector2> waypoints = new List<Vector2>();
    int currentWaypoint = 0;
    bool endReached = false;
    int WaypointCount;
    public bool moving = false;
    Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = waypointPath.transform;
        WaypointCount = tr.childCount;
        for (int i = 0; i < WaypointCount; i++)
            waypoints.Add(tr.GetChild(i).transform.position);
        tr = transform;
        tr.position = waypoints[currentWaypoint];

        if (currentWaypoint >= WaypointCount)
            throw new Exception("There must be at least 2 waypoints for MovingPlatform to Move!");
    }


    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        if (!waypointPath) return;
        for (int i = 0; i < waypointPath.transform.childCount - 1; i++)
            Gizmos.DrawLine(waypointPath.transform.GetChild(i).transform.position, waypointPath.transform.GetChild(i+1).transform.position);
    }

    public void StartMoving()
    {
        moving = true;
    }

    public void StopMoving()
    {
        moving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!moving) return;
        if (Vector2.Distance(waypoints[currentWaypoint], transform.position) < .1f)
        {
            if (!endReached)
                currentWaypoint++;
            else
                currentWaypoint--;

            if (currentWaypoint == waypoints.Count - 1)
                endReached = true;
            else if (currentWaypoint == 0)
                endReached = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint], speed * Time.deltaTime); ;

    } 
}