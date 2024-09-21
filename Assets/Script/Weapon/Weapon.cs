using Unity.Mathematics;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    private Transform BulletHolder;
    
    private void Start()
    {
        BulletHolder = new GameObject("BulletHolder").transform;
    }
    
    public void Emit(Vector3 direction)
    {
        var b = Instantiate(bullet, transform.position, quaternion.identity,BulletHolder);
        b.transform.localScale *=  0.25f;
        var dir = b.AddComponent<GoToDirection>();
        dir.direction = direction;

        Destroy(b, 2);
    }
}