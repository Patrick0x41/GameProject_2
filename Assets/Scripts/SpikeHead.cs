using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeHead : Trap
{

    [SerializeField] private int SpikeHeaddamage;
    // Start is called before the first frame update
    void Start()
    {
        TrapDamage = SpikeHeaddamage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
