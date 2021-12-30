using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItem : MonoBehaviour
{
    [SerializeField] private HealthBar HB;
    [SerializeField] private PlayerLife PL;
    [SerializeField] private MagicBar MB;
    [SerializeField] private PlayerCombat PC;
    [SerializeField] private AudioSource appleCollectSoundEffect;
    [SerializeField] private AudioSource MagicPotionCollectSoundEffect;
    [SerializeField] private AudioSource HealthPotionCollectSoundEffect;

    [SerializeField] GameObject apple;

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Apple"))
        {
            if(PL.isHealthFull)
            {
                return;
            }
            else
            {    //GetComponent<AudioSource>().Play();
                appleCollectSoundEffect.Play();
                Destroy(other.gameObject); // destroy apple
                // Increase the health of player by 10 HP
                PL.increaseHealth(15);
                Debug.Log("Apple has been collected");
            }
        }
        else if(other.CompareTag("MagicPotion"))
        {
            if(PC.isMagicFull)
            {
                return;
            }
            else
            {   
                // Play audio
                MagicPotionCollectSoundEffect.Play();
                Destroy(other.gameObject);
                PC.increaseMagic(5);
                //Debug.Log("Magic has been collected");
            }
        }

        if(other.CompareTag("Potion"))
        {
                HealthPotionCollectSoundEffect.Play();
                Destroy(other.gameObject); // destroy apple
                // Increase the health of player by 10 HP
                PL.increaseHealth(50);
                Debug.Log("Health Potion has been collected");
        }
    }
    
}
