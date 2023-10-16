using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalStoneDestroy : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject,0.2f);
        }
    }
}
