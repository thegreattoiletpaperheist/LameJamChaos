using UnityEngine;

public class WeaponAimTarget : MonoBehaviour
{
    private Enemy _enemy;
    private Weapon _weapon;
    void Start()
    {
        _enemy = GetComponent<Enemy>();
        _weapon = GetComponentInChildren<Weapon>();
    }

    private float _lastSpawnTime;
    public float SpawnPeriod = 1f;
    public float RandomPeriod = 3f;
    public float Fallof = 3f;
    
    void Update()
    {
        if ((Time.time - _lastSpawnTime) > SpawnPeriod)
        {
            var target = ( (_enemy.Target.position + (Vector3)Random.insideUnitCircle * Fallof)  - transform.position).normalized;
            _weapon.Emit(target);
            _lastSpawnTime = Time.time + Random.Range(0, RandomPeriod);
        }
    }
}
