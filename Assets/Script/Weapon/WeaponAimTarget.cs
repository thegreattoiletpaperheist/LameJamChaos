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

    public void Pickup(GameObject Item)
    {
        _weapon = Item.GetComponent<Weapon>();
    }

    private float _lastSpawnTime;
    public float SpawnPeriod = 1f;
    public float RandomPeriod = 3f;
    public float Fallof = 3f;
    
    void Update()
    {
        if (_weapon)
        {
            if ((Time.time - _lastSpawnTime) > SpawnPeriod)
            {
                var target = ((_enemy.Target.position + (Vector3)Random.insideUnitCircle * Fallof) - transform.position)
                    .normalized;
                _weapon.Emit(target);
                _lastSpawnTime = Time.time + Random.Range(0, RandomPeriod);
            }

            Vector3 difference = _enemy.Target.position - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            _weapon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            _weapon.GetComponent<SpriteRenderer>().flipY = difference.x < 0;
            
        }
    }
}
