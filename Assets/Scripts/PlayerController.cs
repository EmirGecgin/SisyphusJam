using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rigidBody;
    [SerializeField] private float verticalSpeed,horizontalSpeed,jumpForce;
    private float _moveHorizontal, _moveVertical;
    [SerializeField] private bool isOnGrounded=true;
    void Start()
    {
        
        _rigidBody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        _moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.W))
        {
            verticalSpeed = 40;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            verticalSpeed = 15;
        }
        else if (Input.GetKeyDown(KeyCode.W)&&Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.W)&&Input.GetKeyDown(KeyCode.D))
        {
            verticalSpeed = 10;
            horizontalSpeed = 20;
        }
        else if (Input.GetKeyDown(KeyCode.S)&&Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)&&Input.GetKeyDown(KeyCode.D))
        {
            verticalSpeed = 10;
            horizontalSpeed = 20;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&isOnGrounded)
        {
            isOnGrounded = false;
            
            if ((Input.GetKey(KeyCode.W)))
            {

                
               
                isOnGrounded = false;
                _rigidBody.AddForce(Vector3.up*jumpForce*1.25f);
                Debug.Log(jumpForce);
                
            }
            else
            {
                _rigidBody.AddForce(Vector3.up*jumpForce);
            }
            
        }
        else if (Input.GetKeyUp(KeyCode.Space)&&!(isOnGrounded))
        {
            _rigidBody.mass = 2;
            Physics.gravity = new Vector3(0, -20.0f, 0);
        }
        
        //Debug.Log(_rigidBody.velocity);
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(_moveHorizontal*horizontalSpeed,0, _moveVertical*verticalSpeed)*Time.fixedDeltaTime;
        _rigidBody.AddForce(movement,ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGrounded = true;
        }
    }
}
