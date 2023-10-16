using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody _rb;
    public GameObject MainChar;
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
       
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rb.AddForce(0,0,-10);
        
    }
   
}
