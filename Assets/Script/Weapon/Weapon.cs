using System;
using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    private Transform BulletHolder;

    public float BulletsPerMinute = 60;
    private float lastShotFired = 0;

    public bool CanShoot;
    
    private void Start()
    {
        BulletHolder = new GameObject("BulletHolder").transform;
    }
    
    public void Emit(Vector3 direction)
    {
        if(!CanShoot)
            return;
        
        var b = Instantiate(bullet, transform.position, quaternion.identity,BulletHolder);
        b.transform.localScale *=  0.25f;
        var dir = b.AddComponent<GoToDirection>();
        dir.direction = direction;

        Destroy(b, 2);
        
        lastShotFired = Time.time;
    }
    
    public void Update()
    {
        CanShoot = (Time.time - lastShotFired) > ( 60 / BulletsPerMinute);
    }
}