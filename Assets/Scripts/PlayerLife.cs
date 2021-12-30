using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayerLife : MonoBehaviour
{

    private Animator anim;
    private Rigidbody2D body;
    
    public LifeCount lifeCount;
     public int health; // current health of player
    public int maxHealth; // max health of player

    public bool dead;
    [HideInInspector] public int currentNumberOfLives; // current number of lives 
    public HealthBar healthBar; 
    [SerializeField] private AudioSource death;
    [SerializeField] private AudioSource Hurt;
    public bool isHealthFull;
    public bool isHealthZero;
    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //healthBar = GetComponent<HealthBar>().setMaxHealth(maxHealth);
        healthBar.setMaxHealth(maxHealth); // set the bar to the max health
        health = maxHealth; // health will be at first the max health
        currentNumberOfLives = lifeCount.numberOfLives; // the current # of lives is the maximum # of lives
        isHealthFull = true;
        isHealthZero = false;

    }

    void Die()
    {
        Debug.Log("Dead");
        dead = true;
        death.Play();
        anim.SetTrigger("Death");
        body.bodyType = RigidbodyType2D.Static;
        GetComponent<BoxCollider2D>().enabled = false;
        gameObject.SetActive(false); // disable player
        //GetComponent<PlayerLife>().StopAllCoroutines();
        // function is called in the animation
        // call the lose life function
        // lifeCount.loseLife();
        
    }

    public void increaseHealth(int regen)
    {
        if(health >= maxHealth)
        {
            // don't increase
            isHealthFull = true;
            return;
        }
        else
        {
            isHealthFull = false;
            health+=regen;
            healthBar.setHealth(health);
        }
    }
    public void takeDamage(int damage)
    {
        // player takes damage from an enemy or a trap
    
        if(health <= 0) // if health is less than or equal 0, decrement from lives and restart
        {
            //isHealthZero = true;
            if(!dead)
            Die();
        }
            dead = false;
            isHealthZero = false;
            Hurt.Play(); /// play the hurt audio
            anim.SetTrigger("Hurt");
            health-=damage;
            healthBar.setHealth(health); // Call the function from health bar class to change the slider
            isHealthFull = false;

    }

    void update()
    {
       
    }
}
