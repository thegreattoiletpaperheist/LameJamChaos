using UnityEngine;

public class EnemyBlow : MonoBehaviour
{
    public Transform target;
    public float BlowRadius = 2;

    private Mob _mob;
    private Stats _stats;

    private void Start()
    {
        _mob = GetComponent<Mob>();
        _stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        if ((target.position - transform.position).magnitude < BlowRadius)
        {
            target.GetComponent<Health>().DoDamage(_stats.DamageOnCollision);
            _mob.Died();
        }
    }
}