using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{

    public static bool isGamePaused = false;
    public GameObject PauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            ResumeMethod();
            else
            PauseMethod();
        }
    }

    public void ResumeMethod()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f; // unfreeze
        isGamePaused = false;
    }
    void PauseMethod()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f; // freeze
        isGamePaused = true;
    }
}
