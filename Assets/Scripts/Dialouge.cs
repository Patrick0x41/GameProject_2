using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Dialouge : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    private string[] dialougeSentences;
    private int inde = 0;
    public float typingspeed;
    public GameObject continueButton;
    public GameObject dialougeBox;
    public PlayerMovement player;
    int index = 0;

    // Start is called before the first frame update
    public IEnumerator TypeDialogue() 
    {
        dialougeBox.SetActive(true);
        //player.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY;
        player.PausePlayer(true);
        textDisplay.text = "";
        foreach (char letter in dialougeSentences[index].ToCharArray()) 
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingspeed);
        }
        yield return null;
        
        if (textDisplay.text.Equals(dialougeSentences[index])) 
        {
            continueButton.SetActive(true);
        }
    }
    public void SetSentences(string[] sentences) 
    {
        this.dialougeSentences = sentences;
    }
    public void NextSentence() 
    {
        continueButton.SetActive(false);
        if (index < dialougeSentences.Length - 1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(TypeDialogue());
        }
        else 
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            dialougeBox.SetActive(false);
            this.dialougeSentences = null;
            index = 0;
            player.PausePlayer(false);

        }
    }
    void Start()
    {
        dialougeBox.SetActive(false);
        continueButton.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
