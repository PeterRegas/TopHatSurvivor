using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletRandom : MonoBehaviour
{
    public int shotSpeed = 10;
    public float range = 1;
    public float damage = 5;
    public Rigidbody2D bulletPhysics;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,range);
        //picks random direction
        Vector2 shotDir = Random.insideUnitCircle;
        shotDir.Normalize();
        //rotates bullet to the direction its being shot
        bulletPhysics.rotation = Mathf.Atan2(shotDir.y, shotDir.x) * Mathf.Rad2Deg;
        //changes the speed of the bullet to the shotspeed
        bulletPhysics.velocity = shotDir * shotSpeed;
        //changes damage based off player level
        damage += GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().level*1.2f;
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        //if bullet hits enemy do damage
        if(thing.tag == "enemy"){
            thing.GetComponent<enemy>().Hit(damage);
            Destroy(gameObject);
        }
        
    }
}
