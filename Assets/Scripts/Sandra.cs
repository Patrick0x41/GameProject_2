using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandra : MonoBehaviour
{

    public Transform player;

    private bool isFlipped = false;
    [SerializeField] int health;
    [SerializeField] int BossDamage;
    [SerializeField] private int maxHealth;
    [SerializeField] private int enrangedMaxHealth;
     [SerializeField] private HealthBar healthBar;
    private Animator anim;
    public Transform[] birdRespawnPoints;
    public GameObject[] birds;
    [SerializeField] float respawnRate; // current
    [SerializeField] float respawnTime; // starting duration
    public bool isEnranged;
    public bool isVulnerable;
    public EnemyHealthBar bossHealthBar;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        health = maxHealth;
        healthBar.setMaxHealth(maxHealth);
        isEnranged = false;
        respawnRate = respawnTime;
        isVulnerable = true;
        bossHealthBar.setHealth(health,maxHealth);
        
    }

    // Update is called once per frame
    void Update()
    {

        if(respawnRate <= respawnTime)
        {
            //RespawnBird();
            //Debug.Log(respawnRate);
            respawnRate-=Time.deltaTime;
        }
        if(respawnRate <= 0)
        {
            RespawnBird();
            respawnRate = respawnTime;
        }
        
    }

    public void lookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *=-1f;
        if(transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            isFlipped = false;
        }
        else if(transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f,180f,0f);
            isFlipped = true;
        }
    }


    public void GiveDamage()
    {
        if(player.GetComponent<PlayerLife>().dead)
        anim.SetTrigger("Idle");

        FindObjectOfType<PlayerLife>().takeDamage(BossDamage);
    }
    public void takeDamage(int damage)
    {
        if(!isVulnerable)
        return;
        
        health-=damage;
        bossHealthBar.setHealth(health,maxHealth);

        //healthbar.setHealth(currentHealth);
        anim.SetTrigger("Hurt");
        /*if(health < 50)
        {
            isEnranged = true;
            anim.SetBool("isEnranged",true);
        }*/
        if(health <= 0 && !isEnranged)
        {
            isEnranged = true;
            anim.SetBool("isEnraged" , true);
            health = enrangedMaxHealth;
            bossHealthBar.setHealth(health,enrangedMaxHealth);

            //GetComponent<Transform>().localScale = new Vector2(-8f,8f);
        }
        if(health <= 0 && isEnranged)
        {
            Die();
        }
    }
    void Die()
    {
        anim.SetBool("Death",true);
        GetComponent<Collider2D>().enabled = false; // to pass through the corpse
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic; // for the corpse not to fall
        this.enabled = false; // disable the enemy script
        bossHealthBar.slider.gameObject.SetActive(false);
    }

    void RespawnBird()
    {
        // Instantiate bird
        for(int i = 0; i<birds.Length; i++)
        {
            Instantiate(birds[i],birdRespawnPoints[i].position,birdRespawnPoints[i].rotation);
        }
    }


    
}
