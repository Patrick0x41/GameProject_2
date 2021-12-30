using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMovement : MonoBehaviour
{

    private Rigidbody2D body;
    private Animator anim;
    [SerializeField] private int RunSpeed;
    [SerializeField] private int JumpSpeed;
    //public float localScaleOfX;
    private float HorizontalInput;
    private bool grounded; // check if the player is on ground
    private bool isPaused;

    //private bool firstAttack = false; wrong
    public void PausePlayer(bool input)
    {
        isPaused = input;
        body.velocity = Vector2.zero;
        anim.SetBool("Run", false);
    }

    // Start is called before the first frame update

    void Start()
    {
       body = GetComponent<Rigidbody2D>();
       anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused)
            return;
        HorizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(Input.GetAxis("Horizontal") * RunSpeed, body.velocity.y);

        if(HorizontalInput > 0.01f) // Moving right
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y,transform.localScale.z);
        }
        if(HorizontalInput < -0.01f) // Moving left
        {
            transform.localScale = new Vector3(-(Mathf.Abs(transform.localScale.x)), transform.localScale.y,transform.localScale.z);

        }
        if(Input.GetKey(KeyCode.Space) && grounded)
        {
            jump();
        }
        if(Input.GetKey(KeyCode.C))
        {
            Crouch();
        }

        // Animations
        anim.SetBool("Run",HorizontalInput!=0);
        anim.SetBool("Grounded",grounded);
    }

   

    void jump()
    {
        body.velocity = new Vector2(body.velocity.x,JumpSpeed);
        grounded = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    public void Crouch()
    {
        anim.SetTrigger("Crouch");
    }
}
