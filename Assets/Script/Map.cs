using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Map : MonoBehaviour
{

    public List<GameObject> tiles;

    public List<GameObject> spawned;
    void Start()
    {
        int border = 20;
        for (int i = -border; i < border; i++)
        {
            for (int j = -border; j < border; j++)
            {
                int tileIndex = Random.Range(0, tiles.Count);
                var go =Instantiate(tiles[tileIndex], new Vector3(i, j, transform.position.z),quaternion.identity,transform);
                spawned.Add(go);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
