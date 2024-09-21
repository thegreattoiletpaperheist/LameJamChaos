
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.AddComponent<WeaponAimCursor>();

        var targetAim = gameObject.GetComponent<WeaponAimTarget>();
        if (targetAim)
        {
            Destroy(targetAim);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
