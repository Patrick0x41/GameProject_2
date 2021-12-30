using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private LayerMask EnemyLayer;
    [SerializeField] private LayerMask BossLayer;
    [SerializeField] private LayerMask BirdLayer;


    [SerializeField] public int attackDamage1;
    //[SerializeField] private int attackDamage2;
    [SerializeField] private int attackDamage3;
    public HealthBar healthbar;
    public MagicBar magicBar;
    public int magicFireBlasts; // max magic blasts
    [SerializeField] private int currentMagicFireBlasts; // current magic blasts
    
    /*[SerializeField] private AudioClip swordSound1;
    [SerializeField] private AudioClip swordSound2;
    [SerializeField] private AudioClip swordSound3;
    */

    [SerializeField] private AudioSource swordAttack1;
    [SerializeField] private AudioSource swordAttack2;
    [SerializeField] private AudioSource swordAttack3;
    [SerializeField] private AudioSource noMagicBlasts;
    public bool isMagicFull;

    [SerializeField] private Shoot shoot;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        currentMagicFireBlasts = magicFireBlasts;
        shoot = GetComponent<Shoot>();
        magicBar.setMaxMagic(currentMagicFireBlasts);
        isMagicFull = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) // First Attack
        {
            swordAttack1.Play(); // Play the audio clip
            FirstAttack(); // animate the attack and damage any enemy
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(currentMagicFireBlasts == 0)
            {
                Debug.Log("No magic blasts");
                noMagicBlasts.Play();
                return;
            }
            else
            {
                swordAttack2.Play();
                SecondAttack();
            }
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            swordAttack3.Play();
            ThirdAttack();
        }
    }

    void FirstAttack()
    {
        anim.SetTrigger("FirstAttack");
        Collider2D [] enemies = Physics2D.OverlapCircleAll(attackPoint.position , attackRange , EnemyLayer);
        Collider2D [] bosses = Physics2D.OverlapCircleAll(attackPoint.position , attackRange , BossLayer);
        Collider2D [] birds = Physics2D.OverlapCircleAll(attackPoint.position , attackRange , BirdLayer);
        foreach(Collider2D demon in enemies)
        {
            demon.GetComponent<Demon>().takeDamage(attackDamage1);
            //Debug.Log("We hit " + demon.name);
        }
        foreach(Collider2D otherEnemy in enemies)
        {
            // call the function of this enemy that takes damage
        }
        foreach(Collider2D boss in bosses)
        {
            boss.GetComponent<Sandra>().takeDamage(attackDamage1);
        }
        foreach(Collider2D bird in birds)
        {
            bird.GetComponent<Bird>().takeDamage(attackDamage1);
        }
    }

    void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        return;

        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
    void SecondAttack()
    {
        if(currentMagicFireBlasts <= magicFireBlasts)
        {
            currentMagicFireBlasts--;
            isMagicFull = false;
            magicBar.setMagic(currentMagicFireBlasts);
            anim.SetTrigger("SecondAttack");
            shoot.shoot(); // instantiate new magic blast
            /*Collider2D [] enemies = Physics2D.OverlapCircleAll(attackPoint.position , attackRange , EnemyLayer);

            foreach(Collider2D enemy in enemies)
            {
                enemy.GetComponent<Enemy>().takeDamage(attackDamage2);
            }*/

        }
    }
    void ThirdAttack()
    {
        anim.SetTrigger("ThirdAttack");
        Collider2D [] enemies = Physics2D.OverlapCircleAll(attackPoint.position , attackRange , EnemyLayer);
        Collider2D [] bosses = Physics2D.OverlapCircleAll(attackPoint.position , attackRange , BossLayer);
        Collider2D [] birds = Physics2D.OverlapCircleAll(attackPoint.position , attackRange , BirdLayer);
        foreach(Collider2D enemy in enemies)
        {
            enemy.GetComponent<Enemy>().takeDamage(attackDamage3);
        }
         foreach(Collider2D boss in bosses)
        {
            boss.GetComponent<Sandra>().takeDamage(attackDamage3);
        }
        foreach(Collider2D bird in birds)
        {
            bird.GetComponent<Bird>().takeDamage(attackDamage3);
        }
    }

    public void increaseMagic(int inc)
    {
        if(currentMagicFireBlasts >= magicFireBlasts)
        {
            // Dont increase
            isMagicFull = true;
            return;
        }
        else
        {
            isMagicFull = false;
            currentMagicFireBlasts++;
            magicBar.setMagic(currentMagicFireBlasts);
        }
    }
}
