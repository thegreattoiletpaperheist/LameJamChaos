using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToDirection : MonoBehaviour
{
    public Vector3 direction;

    private Stats _stats;
    private Rigidbody2D _rigidbody2d;
    private void Start()
    {
        _stats = GetComponent<Stats>();
        _rigidbody2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        _rigidbody2d.position += (Vector2)(Time.fixedDeltaTime * direction * _stats.Speed);
        
        Vector3 difference = direction;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
        GetComponent<SpriteRenderer>().flipY = difference.x < 0;
    }
}
