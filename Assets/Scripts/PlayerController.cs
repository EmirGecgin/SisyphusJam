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
    [SerializeField] private int collisonWithPlayer;
    public List<GameObject> healthIcon;

    void Start()
    {
        
        _rigidBody = GetComponent<Rigidbody>();
        collisonWithPlayer = 3;
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
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            collisonWithPlayer--;
            Debug.Log(collisonWithPlayer);
            if (collisonWithPlayer==2)
            {
                healthIcon[2].gameObject.SetActive(false);
            }
            if (collisonWithPlayer==1)
            {
                healthIcon[1].gameObject.SetActive(false);
            }
            if (collisonWithPlayer==0)
            {
                healthIcon[0].gameObject.SetActive(false);
                Time.timeScale = 0;
                Debug.Log("Your are piece of shit!");
                
            }
        }
    }
   
}
