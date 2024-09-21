using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 3.0f;
    private Mob _mob;

    public SpriteRenderer h1;
    public SpriteRenderer h2;
    public SpriteRenderer h3;

    private void Start()
    {
        _mob = GetComponent<Mob>();
    }

    public void DoDamage(float statsDamageOnCollision)
    {
        health -= statsDamageOnCollision;
        if (health <= 0.0f)
        {
            _mob.Died();
        }

        if (health >= 3)
        {
            h1.color = Color.green;
            h2.color = Color.green;
            h3.color = Color.green;
        }
        else if (health>=2)
        {
            h1.color = Color.green;
            h2.color = Color.green;
            h3.color = Color.red;
        }
        else if (health >= 1)
        {
            h1.color = Color.green;
            h2.color = Color.red;
            h3.color = Color.red;
        }
    }
}