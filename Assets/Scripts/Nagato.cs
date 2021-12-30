using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nagato : MonoBehaviour
{
    public Dialouge dialougeManager;
    // Start is called before the first frame update
    public string[] dialouge;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player") 
        {
            dialougeManager.SetSentences(dialouge);
            dialougeManager.StartCoroutine(dialougeManager.TypeDialogue());
        }
        gameObject.SetActive(false);
    }
}
