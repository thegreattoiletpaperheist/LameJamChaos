using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToDirection : MonoBehaviour
{
    public Vector3 direction;

    private Stats _stats;
    private void Start()
    {
        _stats = GetComponent<Stats>();

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Time.deltaTime * direction * _stats.Speed;
    }
}
