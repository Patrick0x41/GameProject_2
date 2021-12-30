using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demon : MonoBehaviour
{

    private int health;
    public int maxHealth;
    
    //public int speed;
    Animator anim;
    public EnemyHealthBar enemyHealthBar;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        
        health = maxHealth; 
        enemyHealthBar.setHealth(health,maxHealth);
        //distanceToPlayer = Vector2.Distance(attackPoint.position, target.position);
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    
    
    public void GiveDamage(int damage)
    {
        FindObjectOfType<PlayerLife>().takeDamage(damage);
    }
    

    public void takeDamage(int damage)
    {
        // Play audio hurt
        // Play animation hurt
        anim.SetTrigger("Hurt");
        health-=damage;
        enemyHealthBar.setHealth(health,maxHealth);
        if(health <= 0)
        {
            Die();
        }

    }
    
    void Die()
    {
        // Play death animation
        // Play death audio
        anim.SetTrigger("Death");
        GetComponent<BoxCollider2D>().enabled = false;
        enemyHealthBar.slider.gameObject.SetActive(false);
    }
}
