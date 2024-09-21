using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class WeaponAimCursor : MonoBehaviour
{
    private Weapon _weapon;
    
    // Start is called before the first frame update
    void Start()
    {
        _weapon = GetComponentInChildren<Weapon>();
    }

    public void Pickup(GameObject item)
    {
        _weapon = item.GetComponentInChildren<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_weapon)
        {
            var cursorWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 direction;
                direction = ( cursorWorldPosition - transform.position).normalized;
                direction.z = 0;
                _weapon.Emit(direction);
            }
            
            Vector3 difference = cursorWorldPosition - transform.position;
            float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
            _weapon.transform.rotation = Quaternion.Euler(0.0f, 0.0f, rotationZ);
            _weapon.GetComponent<SpriteRenderer>().flipY = difference.x < 0;
        }
    }
}
