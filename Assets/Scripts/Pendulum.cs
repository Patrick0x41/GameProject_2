using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Rigidbody2D rb2D;
    public float speed , leftAngle, rightAngle;
    bool movingClockwise;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2D.angularVelocity = speed;
        //Debug.Log(transform.rotation.z);
    }
}
