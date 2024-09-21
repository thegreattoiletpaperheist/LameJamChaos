using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    public float SpawnPeriod = 1f;
    private float _lastSpawnTime;

    public List<GameObject> Buffs;
    public GameObject capsule;
    public CoordinateProvider _CoordinateProvider;

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
        var position = _CoordinateProvider.GetCoordOutsideOfScreen();
        var go = Instantiate(capsule, position, Quaternion.identity, transform);
        var randomIndex = Random.Range(0, Buffs.Count);
        var item = Buffs[randomIndex];
        go.GetComponent<Pickup>().Item = item;
    }
}
