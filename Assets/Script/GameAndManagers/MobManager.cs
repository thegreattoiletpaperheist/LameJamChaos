using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class MobManager : MonoBehaviour
{
    public Transform Target;
    public GameObject MobPrefab;

  public float SpawnPeriod = 1f;
    void Start()
    {
    }

    private float _lastSpawnTime;
  
    void Update()
    {
        if ((Time.time - _lastSpawnTime) > SpawnPeriod)
        {
            SpawnOutOfScreen();
            _lastSpawnTime = Time.time;
        }
    }

    private void SpawnOutOfScreen()
    {
        var camera = Camera.main;
        var cameraTransform = camera.transform;
        var cameraPosition = cameraTransform.position;

        var lowerLeft = camera.ViewportToWorldPoint(Vector3.zero);
        var upperRight = camera.ViewportToWorldPoint(Vector3.one);
        var maxR = (lowerLeft - cameraPosition).magnitude > (upperRight - cameraPosition).magnitude
            ? lowerLeft
            : upperRight;

        var radius = maxR - cameraPosition;
        var magnitude = radius.magnitude;
        
        var direction = Random.insideUnitCircle.normalized;

        var newPosition = direction * (magnitude + 1);
            
        Spawn(new Vector3(newPosition.x, newPosition.y , transform.position.z));
    }

    public void Spawn(Vector3 position)
    {
        var go = Instantiate(MobPrefab, position, quaternion.identity, transform);
        go.AddComponent<Enemy>().Target = Target;
        
        go.GetComponent<SpriteRenderer>().color = Color.red;

        var blow = go.AddComponent<EnemyBlow>();
        blow.target = Target;
    }
}
