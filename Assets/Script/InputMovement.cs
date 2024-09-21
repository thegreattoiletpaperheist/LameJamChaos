using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    private Stats _stats;
    private void Start()
    {
        _stats = GetComponent<Stats>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += _stats.Speed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.W))
        { 
            transform.position += _stats.Speed * Time.deltaTime * Vector3.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += _stats.Speed * Time.deltaTime * Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += _stats.Speed * Time.deltaTime * Vector3.down;
        }
    }
}