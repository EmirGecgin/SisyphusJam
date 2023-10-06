using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private Rigidbody _rigidBody;
    [SerializeField] private float verticalSpeed,horizontalSpeed,anglerForce;
    private float moveHorizontal, moveVertical;
   
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody>();
      
    }

    private void Update()
    {
        moveHorizontal = Input.GetAxis("Horizontal");
        moveVertical = Input.GetAxis("Vertical");
        if (Input.GetKey(KeyCode.W))
        {
            verticalSpeed = 60;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalSpeed = 1;
        }
        else
        {
            verticalSpeed = 0;
        }
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveHorizontal*horizontalSpeed,0, moveVertical*verticalSpeed).normalized;
        
        _rigidBody.AddForce(movement,ForceMode.VelocityChange);

    }
  
   

}
