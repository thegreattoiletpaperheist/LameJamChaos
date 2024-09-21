
using UnityEngine;

public class Player : MonoBehaviour
{
    private WeaponAimCursor _aim;

    private Weapon _weapon;
    void Start()
    {
         _aim = gameObject.AddComponent<WeaponAimCursor>();

        var targetAim = gameObject.GetComponent<WeaponAimTarget>();
        if (targetAim)
        {
            Destroy(targetAim);
        }

        gameObject.AddComponent<InputMovement>();
        GetComponent<AnimatedMob>().enabled = false;
    }
    
    public void PickUp(GameObject spawned)
    {
        if(_weapon)
            Destroy(_weapon.gameObject);
        
        _aim.Pickup(spawned);
        
        _weapon = spawned.GetComponent<Weapon>();
    }
}
