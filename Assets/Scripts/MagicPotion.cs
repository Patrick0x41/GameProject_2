using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicPotion : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Potion"))
        {
            potionCollectSoundEffect.Play();
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("MagicPotion"))
        {
            apple.GetComponent<AudioSource>().Play();
            Destroy(other.gameObject);
            MB.GetComponent<MagicBar>().setMagic(1);
        }
    }
    */
}
