using UnityEngine;

public class Mob : MonoBehaviour
{
    public bool alive = true;

    public void Died()
    {
        if (!alive)
            return;
    
        Destroy(gameObject);
        Debug.Log("Me die");
    }
}