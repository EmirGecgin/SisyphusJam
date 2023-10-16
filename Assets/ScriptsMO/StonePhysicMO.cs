using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StonePhysicMO : MonoBehaviour
{
    public int gravity;
    private Rigidbody _rb;
    public GameObject MainChar;
    void Start()
    {
        Physics.gravity = new Vector3(0,gravity,0);
    }

    // Update is called once per frame
    private void Update()
    {
        if (MainChar.transform.position.z > transform.position.z+15)
        {
            ReloadaScene.looseOk = true;
        }
    }
}
