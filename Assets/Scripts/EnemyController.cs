using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //---------- Enemy Variables ------------
    public int health = 5;
    public int damage = 1;
    public float speed = 1.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    public void UpdatePosition()
    {
        var step =  speed * Time.deltaTime; // calculate distance to move
        Vector3 playerPositon =  GameObject.FindGameObjectsWithTag("Player")[0].transform.position;
        this.transform.position = Vector3.MoveTowards(this.transform.position, playerPositon, step);

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, playerPositon - transform.position, step, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDirection);
    }

    public void GetDamage()
    {
        this.health--;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void Attack()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //If the GameObject has the same tag as specified, output this message in the console
            Debug.Log("HIT PLAYER");
            Destroy(gameObject);
        }
    }
}
