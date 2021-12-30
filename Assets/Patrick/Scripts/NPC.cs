using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{

    Animator anim;
    WaypointFollower wp;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        wp = GetComponent<WaypointFollower>();
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < wp.waypoints[wp.currentWaypointIDX].transform.position.x)
        {
            transform.localScale = new Vector2(1,transform.localScale.y);
            anim.SetBool("Walk" , true);
        }
        else
        {
            transform.localScale = new Vector2(-1,transform.localScale.y);
            anim.SetBool("Walk",true);
        }
    }
}
