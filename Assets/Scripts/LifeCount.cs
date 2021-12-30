using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeCount : MonoBehaviour
{
    [HideInInspector] public int numberOfLives; // lives of player
    public Image[] lives; 
    public LevelManager lm;
    // Start is called before the first frame update
    void Start()
    {
        numberOfLives = lives.Length;
        lm = GetComponent<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loseLife()
    {
        if(numberOfLives == 0) // if no lives, game over
        {
            //Play a lose audio clip
            //FindObjectOfType<LevelManager>().RespawnAtStart();
            Debug.Log("GAME OVER"); // test if it works
        }
        else
        {
            numberOfLives--; // lose one life of the lives
            lives[numberOfLives].enabled = false; // hide the lost life
            lm.RespawnPlayer();
            //RespawnAtStart(); // when dead, restart the scene
        }
    }
}
