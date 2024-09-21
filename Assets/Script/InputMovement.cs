using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMovement : MonoBehaviour
{
    public float speed = 1;
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += speed * Time.deltaTime * Vector3.left;
        }
        if (Input.GetKey(KeyCode.W))
        { 
            transform.position += speed * Time.deltaTime * Vector3.up;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += speed * Time.deltaTime * Vector3.right;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += speed * Time.deltaTime * Vector3.down;
        }
    }
}