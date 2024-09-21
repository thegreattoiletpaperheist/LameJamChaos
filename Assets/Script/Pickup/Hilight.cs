using System;
using UnityEngine;

public class Hilight : MonoBehaviour
{
    public CoordinateProvider _CoordinateProvider;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public bool Visible;

    private void Update()
    {
        Visible = _CoordinateProvider.OnScreen(transform.parent.position);
        sr.enabled = !Visible;

        transform.position = _CoordinateProvider.GetEdgeScreenLocaiton(transform.parent.position);

    }
}