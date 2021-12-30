using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossRun2 : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb2D;
    public int speed = 3;
    Sandra sandra;
    public float attackRange;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb2D = animator.GetComponent<Rigidbody2D>();
        sandra = animator.GetComponent<Sandra>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        sandra.lookAtPlayer();
        Vector2 target = new Vector2(player.position.x,rb2D.position.y);
        Vector2 newPosition = Vector2.MoveTowards(rb2D.position,target,speed*Time.fixedDeltaTime);
        rb2D.MovePosition(newPosition);

        if(Vector2.Distance(player.position,rb2D.position) <= attackRange)
        {
            animator.SetTrigger("SecondAttack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("SecondAttack");
    }
}
