using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatedMob : MonoBehaviour
{
    public int index;
    public List<Sprite> Sprites;
    private SpriteRenderer _sr;

    public float timePerFrame = 0.3f;
    private float lastFrame = 0;
    void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        index = Random.Range(0, Sprites.Count);
        _sr.sprite = Sprites[index];
    }

    // Update is called once per frame
    void Update()
    {
        if ((Time.time - lastFrame) > timePerFrame)
        {
            lastFrame = Time.time;
            index++;
            index %= Sprites.Count;
            _sr.sprite = Sprites[index];
        }
    }
}
