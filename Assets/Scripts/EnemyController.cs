using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    // Superclass for all enemies scripts
    // each enemy has
    [SerializeField] public float speed;

    //[SerializeField] protected bool isFacingLeft = true;
    [SerializeField] protected int damage;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GiveDamage(int damage)
    {
        FindObjectOfType<PlayerLife>().takeDamage(damage);
    }
    public void TakeDamage(int damage)
    {
        
    }
}
