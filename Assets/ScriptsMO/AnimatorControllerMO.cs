using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorControllerMO : MonoBehaviour
{
    Animator mainAnim;
    public GameObject main;
    Rigidbody rb;
    void Start()
    {
        mainAnim = GetComponent<Animator>();
        rb = main.GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown(KeyCode.W)|| rb.velocity.z>0.2f || Input.GetKeyDown(KeyCode.S))&&!( Input.GetKey(KeyCode.Q)))
        {
            mainAnim.SetBool("RunOk", true);
        }
        else if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            mainAnim.SetBool("RunOk", false);
        }

        if (Input.GetKeyDown(KeyCode.Q)||Input.GetButtonDown("Punch"))
        {
            mainAnim.SetBool("PunchOk", true);
        }
        else if (Input.GetKeyUp(KeyCode.Q) || Input.GetButtonUp("Punch"))
        {
            mainAnim.SetBool("PunchOk", false);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            mainAnim.SetBool("JumpOk", true);
           // mainAnim.SetBool("RunOk", false);
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            mainAnim.SetBool("JumpOk", false);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            mainAnim.SetBool("LeftOk", true);
            // mainAnim.SetBool("RunOk", false);
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            mainAnim.SetBool("LeftOk", false);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            mainAnim.SetBool("RightOk", true);
            // mainAnim.SetBool("RunOk", false);
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            mainAnim.SetBool("RightOk", false);
        }

    }
}
