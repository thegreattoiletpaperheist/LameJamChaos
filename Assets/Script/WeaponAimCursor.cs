using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAimCursor : MonoBehaviour
{
    private Weapon _weapon;
    
    // Start is called before the first frame update
    void Start()
    {
        _weapon = GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_weapon)
        {
            if (Input.GetMouseButtonDown(0))
            {   
                var cursorWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                Vector3 direction;
                direction = ( cursorWorldPosition - transform.position).normalized;
                direction.z = 0;
                _weapon.Emit(direction);
            }
        }
    }
}
