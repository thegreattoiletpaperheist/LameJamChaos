using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    private Stats _stats;
    private SpriteRenderer _sr;
    private void Start()
    {
        _stats = GetComponent<Stats>();
        _sr = GetComponent<SpriteRenderer>();
    }

    private bool flipX;

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += _stats.Speed * Time.deltaTime * Vector3.left;
            flipX = true;
        }
        if (Input.GetKey(KeyCode.W))
        { 
            transform.position += _stats.Speed * Time.deltaTime * Vector3.up;
            flipX = true;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += _stats.Speed * Time.deltaTime * Vector3.right;
            flipX = false;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += _stats.Speed * Time.deltaTime * Vector3.down;
            flipX = false;
        }

        _sr.flipX = flipX;
    }
}