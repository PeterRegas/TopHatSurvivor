using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int shotSpeed = 10;
    public float range = 1;
    public float damage = 5;
    public Rigidbody2D bulletPhysics;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,range);
        //gets mouse position
        Vector2 shotDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        shotDir.Normalize();
        //rotates bullet to the direction its being shot
        bulletPhysics.rotation = Mathf.Atan2(shotDir.y, shotDir.x) * Mathf.Rad2Deg;
        //changes the speed of the bullet to the shotspeed
        
        //changes the shot speed to allow you to shoot in the direction you are walking without the bullets being slow
        if((GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().xDirection>0 & shotDir.x>0) 
        | (GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().xDirection<0 & shotDir.x<0) 
        | (GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().yDirection>0 & shotDir.y>0) 
        | (GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().yDirection<0 & shotDir.y<0)){
            shotSpeed += GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().movementSpeed;
        }
        //changes the speed of the bullet to the shotspeed
        shotDir *= shotSpeed;
        damage += GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().level;
        bulletPhysics.velocity = shotDir;
        
         
        
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
