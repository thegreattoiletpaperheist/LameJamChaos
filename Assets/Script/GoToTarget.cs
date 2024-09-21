using UnityEngine;

public class GoToTarget : MonoBehaviour
{
    public Transform target;

    private Stats _stats;
    private void Start()
    {
        _stats = GetComponent<Stats>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += (target.position - transform.position).normalized * _stats.Speed * Time.deltaTime;
    }
}
