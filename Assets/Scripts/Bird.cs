using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{

    public float speed;
    public Transform player;

    public int health;
    public int maxHealth;
    
    public EnemyHealthBar birdHealthBar;
    public AudioSource birdDeath;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        birdHealthBar.setHealth(health,maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position , player.position,speed*Time.deltaTime);
    }

    public void takeDamage(int damage)
    {
        health-=damage;
        birdHealthBar.setHealth(health,maxHealth);

        if(health <= 0)
        Destroy(gameObject);
    }   

    void Dead()
    {
        birdDeath.Play();
        Destroy(gameObject);
    }


}
