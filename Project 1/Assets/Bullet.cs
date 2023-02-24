using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int shotSpeed = 20;
    public int range = 1;
    public Rigidbody2D bulletPhysics;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,range);
        bulletPhysics.velocity = transform.right * shotSpeed;
        
    }

    void OnTriggerEnter2D(Collider2D thing)
    {
        if(thing.tag == "Enemy"){
            Destroy(gameObject);
        }
        
    }

}
