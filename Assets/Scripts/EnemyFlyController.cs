using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyController : MonoBehaviour
{

    public bool isFlipped = false;
    public float speed;
    public Transform player;
    public float lineOfSite;
    [SerializeField] private Animator anim;
    // Start is called before the first frame update

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distanceToPlayer = Vector2.Distance(player.position,transform.position); // distance between enemy and player
        if(distanceToPlayer < lineOfSite )
        {
             transform.position = Vector2.MoveTowards(transform.position , player.position,speed*Time.deltaTime);
            LookAtPlayer();
            anim.SetBool("moving", true);
        }
   
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position,lineOfSite);

    }
    
}
