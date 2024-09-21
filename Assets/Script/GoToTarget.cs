using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToTarget : MonoBehaviour
{
    public Transform target;

    public float speed = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += (target.position - transform.position).normalized * speed * Time.deltaTime;
    }
}
