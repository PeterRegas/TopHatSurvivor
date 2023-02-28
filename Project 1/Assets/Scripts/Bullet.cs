using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int shotSpeed = 20;
    public int range = 1;
    public int damage = 5;
    public Rigidbody2D bulletPhysics;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,range);
         Vector3 shotDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
         shotDir = shotDir/shotDir.magnitude;
        bulletPhysics.velocity = shotDir * shotSpeed;
        
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        if(thing.tag == "enemy"){
            thing.GetComponent<enemy>().Hit(damage);
            Destroy(gameObject);
        }
        
    }

}
