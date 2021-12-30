using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    public bool isPassed;
    void Start()
    {
        anim = GetComponent<Animator>();
        isPassed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && !isPassed)
        {
            isPassed = true;
            anim.SetTrigger("Checkpoint");
            GetComponent<AudioSource>().Play();
            Debug.Log("Checkpoint");
            //FindObjectOfType<LevelManager>().RespawnPlayer();
        }
    }

}
