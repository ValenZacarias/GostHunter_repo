using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    //---------- Weapon Variables ------------
    public int damage = 1;
    public float weaponCooldown = 2.5f;
    public float flashCooldown = 2.5f;

    public float range = 1f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(Transform weapondEnd)
    {
        
        Vector3 direction = Vector3.forward;
        Ray theRay = new Ray(weapondEnd.position, weapondEnd.TransformDirection(direction * range));
        Debug.DrawRay(weapondEnd.position, weapondEnd.TransformDirection(direction * range));

        if(Physics.Raycast(theRay, out RaycastHit hit, range))
        {
            if (hit.collider.tag == "Enemy")
            {
                Debug.Log("Hit enemy");
                // Enemy enemy = hit.collider.gameObject;
                // enemy.GetDamage();
            }
        }
    }
}
