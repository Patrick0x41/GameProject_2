using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [SerializeField] private Transform shootpoint;
    [SerializeField] private GameObject magicBlast;
  
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    

    public void shoot()
    {
       Instantiate(magicBlast,shootpoint.position,magicBlast.GetComponent<Transform>().rotation);
    }
}
