using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Map : MonoBehaviour
{
    public List<GameObject> tiles;
    public List<GameObject> spawned;

    public Vector3 leftBottom;
    public Vector3 rightTop;

    void Start()
    {
        leftBottom = Camera.main.ViewportToWorldPoint(Vector3.zero);
        rightTop = Camera.main.ViewportToWorldPoint(Vector3.one);

        var left = (int)(leftBottom.x - 0.5);
        var bottom = (int)(leftBottom.y-  0.5);
        var right = (int)(rightTop.x + 1.5);
        var top = (int)(rightTop.y + 1.5);

        for (int i = left; i < right; i++)
        {
            for (int j = bottom; j < top; j++)
            {
                int tileIndex = Random.Range(0, tiles.Count);
                var tile = tiles[tileIndex];
                if(!tile)
                    continue;
                
                var go = Instantiate(tiles[tileIndex], new Vector3(i, j, transform.position.z), quaternion.identity,
                    transform);
                spawned.Add(go);
            }
        }
    }

    void Update()
    {
        var newleftBottom = Camera.main.ViewportToWorldPoint(Vector3.zero);
        var newrightTop = Camera.main.ViewportToWorldPoint(Vector3.one);

        var left = (int)(leftBottom.x - 0.5);
        var bottom = (int)(leftBottom.y- 0.5);
        var right = (int)(rightTop.x + 1.5);
        var top = (int)(rightTop.y + 1.5);

        var newleft = (int)(newleftBottom.x- 0.5);
        var newbottom =(int) (newleftBottom.y- 0.5);
        var newright = (int)(newrightTop.x + 1.5);
        var newtop = (int)(newrightTop.y + 1.5);

        if  (newleft < left ) 
        {
            for (int i = newleft; i < left; i++)
            {
                for (int j = bottom; j <top; j++)
                {
                    int tileIndex = Random.Range(0, tiles.Count);
                    
                    var tile = tiles[tileIndex];
                    if(!tile)
                        continue;
                    
                    var go = Instantiate(tile, new Vector3(i, j, transform.position.z), quaternion.identity,
                        transform);
                    spawned.Add(go);
                }
            }
        }
        
        if  (newbottom < bottom ) 
        {
            for (int i = left; i < right; i++)
            {
                for (int j = newbottom; j <bottom; j++)
                {
                    int tileIndex = Random.Range(0, tiles.Count);
                    
                    var tile = tiles[tileIndex];
                    if(!tile)
                        continue;
                    var go = Instantiate(tile, new Vector3(i, j, transform.position.z), quaternion.identity,
                        transform);
                    spawned.Add(go);
                }
            }
        }
        
        if  (newtop > top ) 
        {
            for (int i = left; i < right; i++)
            {
                for (int j = top; j <newtop; j++)
                {
                    int tileIndex = Random.Range(0, tiles.Count);
                    var tile = tiles[tileIndex];
                    if(!tile)
                        continue;
                    var go = Instantiate(tile, new Vector3(i, j, transform.position.z), quaternion.identity,
                        transform);
                    spawned.Add(go);
                }
            }
        }
        
        if  (newright > right ) 
        {
            for (int i = right; i < newright; i++)
            {
                for (int j = bottom; j <top; j++)
                {
                    int tileIndex = Random.Range(0, tiles.Count);
                    var tile = tiles[tileIndex];
                    if(!tile)
                        continue;
                    var go = Instantiate(tile, new Vector3(i, j, transform.position.z), quaternion.identity,
                        transform);
                    spawned.Add(go);
                }
            }
        }

        List<GameObject> remove = new List<GameObject>();
        for (var index = 0; index < spawned.Count; index++)
        {
            GameObject go = spawned[index];
            var goX = go.transform.position.x;
            var goY = go.transform.position.y;

            if (goX < newleft || goX > newright || goY < newbottom || goY > newtop)
            {
                remove.Add(go);
            }
        }

        foreach (GameObject gameObject in remove)
        {
            spawned.Remove(gameObject);
            Destroy(gameObject);
        }

        leftBottom = newleftBottom;
        rightTop = newrightTop;
    }

    void OnDrawGizmos()
    {
        var leftBottom = Camera.main.ViewportToWorldPoint(Vector3.zero);
        var rightTop = Camera.main.ViewportToWorldPoint(Vector3.one);
    }
}