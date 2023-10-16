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
        jumpForce = 525;
        _rigidBody = GetComponent<Rigidbody>();
        collisonWithPlayer = 3;
        Physics.gravity = new Vector3(0, -20.0f, 0);
        verticalSpeed = 40;

    }
    private void Update()
    {
        _moveHorizontal = Input.GetAxis("Horizontal");
        _moveVertical = Input.GetAxis("Vertical");

        if (Input.GetKeyUp(KeyCode.W)&&( _rigidBody.velocity.z>0.5f))
        {
            verticalSpeed = -50;//40
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            verticalSpeed = 40;//40
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
           
            verticalSpeed = 15;//15
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {

            verticalSpeed = -30;//15
        }
        else if (Input.GetKey(KeyCode.D)&& !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            horizontalSpeed = 30;
            if (Input.GetKey(KeyCode.Space))///////////////////lllllllllll/////////////
            {
                _rigidBody.AddForce(50, 0, 0);
            }
                   
            
        }


        else if (Input.GetKeyDown(KeyCode.D) )//////////////////deneme///////////////////////
        {
            horizontalSpeed = 30;
            

        }



        else if (Input.GetKey(KeyCode.A)&& !Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.S))
        {
            if (Input.GetKey(KeyCode.Space))///////////////////lllllllllll/////////////
            {
                _rigidBody.AddForce(-50, 0, 0);
            }
            horizontalSpeed = 30;
        }


        else if (Input.GetKeyDown(KeyCode.A))//////////////////deneme///////////////////////
        {
            horizontalSpeed = 30;


        }


        else if (Input.GetKeyUp(KeyCode.D) && (_rigidBody.velocity.x > 0.7f))
        {
            //_rigidBody.AddForce(-1100,0,0) ;

           horizontalSpeed = -20;//15
        }
        else if (Input.GetKeyUp(KeyCode.A) && (_rigidBody.velocity.x < -0.7f))
        {
           //_rigidBody.AddForce(1100, 0, 0);
             horizontalSpeed = -20;//15
        }


        else if (Input.GetKeyDown(KeyCode.W)&&Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.W)&&Input.GetKeyDown(KeyCode.D))
        {
           
            verticalSpeed = 10;//10
            horizontalSpeed = 20;//20
        }
        else if (Input.GetKeyDown(KeyCode.S)&&Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)&&Input.GetKeyDown(KeyCode.D))
        {
            verticalSpeed = 10;//10
            horizontalSpeed = 20;//20
        }
        /*
        if (Input.GetKeyDown(KeyCode.Space)&&isOnGrounded||( isOnGrounded&&Input.GetButton("Jump")))// gamepad için
        {
            isOnGrounded = false;
            
            if ((Input.GetKey(KeyCode.W)))
            {

                
               
                isOnGrounded = false;
                _rigidBody.AddForce(Vector3.up*jumpForce*2f);
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
        */
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
            
            CameraShake.Invoke();
           
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
                ReloadaScene.looseOk = true;
                //Time.timeScale = 0;
                Debug.Log("Your are piece of shit!");
                
            }
        }
    }
   
}
