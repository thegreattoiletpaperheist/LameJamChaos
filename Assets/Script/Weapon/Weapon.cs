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
        pos= Vector3.zero;
    }

    private Vector3 pos;
    
    public void Emit(Vector3 direction)
    {
        if(!CanShoot)
            return;

        pos = transform.position + (direction.normalized * 1.2f);
        
        var b = Instantiate(bullet,pos , quaternion.identity,BulletHolder);
        b.transform.localScale *=  0.25f;
        var dir = b.AddComponent<GoToDirection>();
        dir.direction = direction.normalized;

        Destroy(b, 2);
        
        lastShotFired = Time.time;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(pos, 0.3f);
    }

    public void Update()
    {
        CanShoot = (Time.time - lastShotFired) > ( 60 / BulletsPerMinute);
    }
}