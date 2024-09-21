using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DamageOnCollision : MonoBehaviour
{
    private Stats _stats;

    private void Start()
    {
        _stats = GetComponent<Stats>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        var health = col.collider.GetComponent<Health>();
        if (health)
        {
            health.DoDamage(_stats.DamageOnCollision);
        }
    }
}
