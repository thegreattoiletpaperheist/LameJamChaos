using UnityEngine;

public class EnemyBlow : MonoBehaviour
{
    public Transform target;
    public float BlowRadius = 1;
    
    // Update is called once per frame
    void Update()
    {
        if ((target.position - transform.position).magnitude < BlowRadius)
        {
            Destroy(gameObject);
        }
    }
}
