using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform Target;
    // Start is called before the first frame update\

    private WeaponAimTarget _aim;
    
    private Weapon _weapon;

    private void Awake()
    {
        _aim = gameObject.AddComponent<WeaponAimTarget>();
        gameObject.AddComponent<GoToTarget>();
    }

    public void PickUp(GameObject spawned)
    {
        if(_weapon)
            Destroy(_weapon.gameObject);
        
        _aim.Pickup(spawned);
        
        _weapon = spawned.GetComponent<Weapon>();
    }
}
