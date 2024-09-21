using UnityEngine;

public class Mob : MonoBehaviour
{
    public bool alive = true;

    public GameObject DieEffect;

    public void Died()
    {
        if (!alive)
            return;

        if (DieEffect)
        {
            var ps = Instantiate(DieEffect, transform.position, Quaternion.Euler(0, 180, 0));
            Destroy(ps, 5);
        }    
            
        Destroy(gameObject);
        Debug.Log("Me die");
    }
}