using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour
{

    public Transform player;
    public Transform checkPoint;
    public Transform startPoint;
    Checkpoint cp;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = GetComponent<Transform>();
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RespawnPlayer()
    {
        player.GetComponent<SpriteRenderer>().enabled = true;
        player.GetComponent<BoxCollider2D>().enabled = true;
        //player.GetComponent<PlayerLife>().health = player.GetComponent<PlayerLife>().maxHealth;
        //player.GetComponent<HealthBar>().setHealth(player.GetComponent<PlayerLife>().maxHealth); 
        player.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        if(cp.isPassed)
        player.position = checkPoint.position; // respawns to the checkpoint
        else
        RespawnAtStart();
    }
    public void RespawnAtStart()
    {
        player.position = startPoint.position;
    }

}
