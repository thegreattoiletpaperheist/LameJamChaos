using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public GameObject Item;

    public bool Stays = false;

    private void Start()
    {
       Instantiate(Item, transform);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        var Spawned = Instantiate(Item, col.gameObject.transform);
        var enemy =  col.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.PickUp(Spawned);
        }

        var player =  col.gameObject.GetComponent<Player>();
        if (player)
        {
            player.PickUp(Spawned);
        }

        if (!Stays)
        {
            Destroy(gameObject);
        }
    }
}
