using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private GameObject [] waypoints; // Multiple waypoints
    [SerializeField] private float speed; // speed of the moving trap or enemy
    private int currentWaypointIDX = 0; // current waypoint from the array
    // Start is called before the first frame update
    void Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if((Vector2.Distance(waypoints[currentWaypointIDX].transform.position,transform.position) < 0.1f))
        {
            currentWaypointIDX++; 
            rb.velocity = new Vector2(-speed,rb.velocity.y);
            if(currentWaypointIDX>=waypoints.Length) // if the current way point is the last waypoint
            {
                currentWaypointIDX = 0; // set it to the first way point
            }
        }
        //transform.position = Vector3.MoveTowards(transform.position,waypoints[currentWaypointIDX].transform.position, Time.deltaTime * speed);
        rb.velocity = new Vector2(speed,rb.velocity.y);
    }
    
   
    
}
