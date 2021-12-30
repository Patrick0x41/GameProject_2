using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : Trap
{
    [SerializeField] private int sawDamage;
    // Start is called before the first frame update
    void Start()
    {
        TrapDamage = sawDamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
