using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //---------- Enemy Variables ------------
    public int health = 5;
    public int damage = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetDamage()
    {
        this.health--;

        if(health <= 0)
        {
            Destroy(this);
        }
    }

    public void Attack()
    {
        
    }
}
