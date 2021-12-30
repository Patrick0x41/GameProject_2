using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderMovement : MonoBehaviour
{
    private float Vertical; // vertical speed
    private bool isClimbing; // if climbing or not
    private bool isLadder; // if the object is ladder
    private float speed = 5f;
    [SerializeField] private Rigidbody2D rb; // reference to player's rigid body
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        if(isLadder && Mathf.Abs(Vertical) > 0f)
        {
            isClimbing = true;
        }
    }

    // When dealing with physics, use FixedUpdate()
    void FixedUpdate()
    {
        if(isClimbing)
        {
            rb.gravityScale = 0f;
            rb.velocity = new Vector2(rb.velocity.x,Vertical*speed);
        }
        else
            rb.gravityScale = 1f;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Ladder"))
        {
            isLadder = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Ladder"))
        {
            isLadder = false;
            isClimbing = false;
        }
    }
}
