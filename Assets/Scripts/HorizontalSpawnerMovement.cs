using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalSpawnerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
        StartCoroutine("Movement");
    }

    IEnumerator Movement()
    {
        _rb.AddForce(speed,0,0);
        yield return null;
    }
}
