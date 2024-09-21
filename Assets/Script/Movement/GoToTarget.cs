using UnityEngine;

public class GoToTarget : MonoBehaviour
{
    private Stats _stats;
    private Enemy _enemy;
    private void Start()
    {
        _stats = GetComponent<Stats>();
        _enemy = GetComponent<Enemy>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!_enemy)
            return;
        
        transform.position += (_enemy.Target.position - transform.position).normalized * _stats.Speed * Time.deltaTime;
    }
}
