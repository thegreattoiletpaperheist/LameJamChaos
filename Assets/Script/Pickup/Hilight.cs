using System;
using UnityEngine;

public class Hilight : MonoBehaviour
{
    public CoordinateProvider _CoordinateProvider;

    private SpriteRenderer sr;

    private Pickup _pickup;

    private void Start()
    {
        _pickup = transform.parent.GetComponent<Pickup>();
        sr = GetComponent<SpriteRenderer>();
    }

    public bool Visible;

    private void Update()
    {
        if (_pickup.pickedUp)
        {
            Visible = false;
        }
        else
        {
            Visible = !_CoordinateProvider.OnScreen(transform.parent.position);
            transform.position = _CoordinateProvider.GetEdgeScreenLocaiton(transform.parent.position);
        }
        sr.enabled = Visible;
    }
}