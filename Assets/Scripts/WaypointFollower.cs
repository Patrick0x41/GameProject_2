using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    public GameObject [] waypoints; // Multiple waypoints
    [SerializeField] private float speed; // speed of the moving trap or enemy
    public int currentWaypointIDX = 0; // current waypoint from the array

    // Update is called once per frame
    void Update()
    {
        if((Vector2.Distance(waypoints[currentWaypointIDX].transform.position,transform.position) < Mathf.Epsilon))
        {
            currentWaypointIDX++; 
            if(currentWaypointIDX>=waypoints.Length) // if the current way point is the last waypoint
            {
                currentWaypointIDX = 0; // set it to the first way point
            }
        }
        transform.position = Vector3.MoveTowards(transform.position,waypoints[currentWaypointIDX].transform.position,  speed * Time.deltaTime);
        //this.GetComponent<Rigidbody2D>().velocity = Vector3.MoveTowards(transform.position,waypoints[currentWaypointIDX].transform.position, Time.deltaTime * speed);
    }
}
