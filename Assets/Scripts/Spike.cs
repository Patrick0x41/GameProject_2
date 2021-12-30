using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : Trap
{
    // Start is called before the first frame update
    [SerializeField] private int damage;
    void Start()
    {
        TrapDamage = damage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
