using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Pickup : MonoBehaviour
{
    public GameObject Item;

    public bool Stays = false;

    public CoordinateProvider _CoordinateProvider;

    [FormerlySerializedAs("chestOpen")] public Sprite chestOpenSpite;

    private SpriteRenderer _spriteRenderer;

    public bool pickedUp = false;
    
    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
                    
       // Instantiate(Item, transform);

       if (_CoordinateProvider)
         GetComponentInChildren<Hilight>()._CoordinateProvider = _CoordinateProvider;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(pickedUp)
            return;
        
        pickedUp = true;

        _spriteRenderer.sprite = chestOpenSpite;
        
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
            // Destroy(gameObject);
        }
    }
}
