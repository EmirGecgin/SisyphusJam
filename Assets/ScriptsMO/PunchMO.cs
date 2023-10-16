using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PunchMO : MonoBehaviour
{
    Rigidbody rb;
    public Transform muzzle;
    public int speed;
    private bool punchOk,cluchOk;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine("PunchRoutine");
    }

    // Update is called once per frame
    void Update()
    {


        if (punchOk )
        {
            Punch();
            punchOk = false;
        }
        else if (punchOk==false)
        {
            transform.position = muzzle.transform.position;
        }

        


    }
    public void Punch()
    {
        rb.AddForce(0, 0, 5000);
        // vuruþ gerçekleþirken 1 saniye karakter hareketsiz kalabilir
    }


  

    IEnumerator PunchRoutine()
    {
        while(true)
        {
            if (/* Input.GetButton("Jump")*/ Input.GetKeyDown(KeyCode.Q) && !(Input.GetKeyDown(KeyCode.W)))// deðiþtirilebilir
            {
                yield return new WaitForSeconds(1f);
                punchOk = true;
                
                
            }
            /*

            if (punchOk)
            {
                
                Punch();
                // yield return new WaitForSeconds(1f);
                yield return new WaitForSeconds(1f);
                transform.position = muzzle.transform.position;

                punchOk = false;
            }
            
            */

            yield return 0;
        }

        
        
    }
}
