using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MagicBar : MonoBehaviour
{
    [SerializeField] private Slider magicSlider;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setMagic(int magic)
    {
        magicSlider.value = magic; 
    }
    public void setMaxMagic(int magic)
    {
        magicSlider.maxValue = magic; 
        magicSlider.value = magic;
    }

    
}
