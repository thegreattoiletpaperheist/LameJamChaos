using Unity.Mathematics;
using UnityEngine;


public class MobManager : MonoBehaviour
{
    public Transform Target;
    public GameObject MobPrefab;

    public float SpawnPeriod = 1f;

    private float _lastSpawnTime;
    public CoordinateProvider _CoordinateProvider;
    
    void Update()
    {
        if ((Time.time - _lastSpawnTime) > SpawnPeriod)
        {
            Spawn(_CoordinateProvider.GetCoordOutsideOfScreen());
            _lastSpawnTime = Time.time;
        }
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