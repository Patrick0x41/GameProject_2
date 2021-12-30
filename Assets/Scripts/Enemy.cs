using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 200;
    public int currentHealth;
    private Animator anim;
    [SerializeField] private AudioClip hurt;
    //public HealthBar healthbar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        anim = GetComponent<Animator>();
        //healthbar.setMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void takeDamage(int damage)
    {
        currentHealth-=damage;
        //healthbar.setHealth(currentHealth);
        anim.SetTrigger("Hurt");
        if(currentHealth <= 0)
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
    }
}
