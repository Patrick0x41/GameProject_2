using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicBlast : MonoBehaviour
{
    [SerializeField] private int magicBlastDamage;
    [SerializeField] private AudioSource magicBlastExplosion;
    public int speed;
    // Start is called before the first frame update
    void Start()
    {
        if(FindObjectOfType<PlayerMovement>().GetComponent<Transform>().localScale.x < 0)
        {
            Debug.Log("Left");
            GetComponent<Transform>().localScale = new Vector3(transform.localScale.x,-0.5f,transform.localScale.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, GetComponent<Rigidbody2D>().velocity.y);
        }
        else if (FindObjectOfType<PlayerMovement>().GetComponent<Transform>().localScale.x > 0)
        {
            Debug.Log("Right");
            GetComponent<Transform>().localScale = new Vector3(transform.localScale.x,0.5f,transform.localScale.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(speed, GetComponent<Rigidbody2D>().velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Demon"))
        {
            //magicBlastExplosion.Play();
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Demon>().takeDamage(magicBlastDamage);
        }
        if(other.CompareTag("Ground"))
        {
            //magicBlastExplosion.Play();
            Destroy(this.gameObject);
        }
        if(other.CompareTag("Sandra"))
        {
            //magicBlastExplosion.Play();
            Destroy(this.gameObject);
            other.gameObject.GetComponent<Sandra>().takeDamage(magicBlastDamage);
        }
        if(other.CompareTag("Bird"))
        {
            //magicBlastExplosion.Play();
            //Destroy(this.gameObject);
            other.gameObject.GetComponent<Bird>().takeDamage(magicBlastDamage);
        }
    }


}
