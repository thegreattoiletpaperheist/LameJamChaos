using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class DamageOnTrigger : MonoBehaviour
{
    private Stats _stats;

    private void Start()
    {
        _stats = GetComponent<Stats>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var health = col.GetComponent<Health>();
        if (health)
        {
            health.DoDamage(_stats.DamageOnCollision);
        }
    }
}
