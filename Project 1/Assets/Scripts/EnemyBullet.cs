using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public int shotSpeed = 10;
    public int range = 1;
    public int damage = 5;
    public Rigidbody2D bulletPhysics;
    // Start is called before the first frame update
    void Start()
    {

        Destroy(gameObject,range);
        //gets mouse position
        Vector2 shotDir = Random.insideUnitCircle;
        shotDir.Normalize();
        //rotates bullet to the direction its being shot
        bulletPhysics.rotation = Mathf.Atan2(shotDir.y, shotDir.x) * Mathf.Rad2Deg;
        //changes the shot speed to allow you to shoot in the direction you are walking without the bullets being slow
        if((GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().xDirection>0 & shotDir.x>0) 
        | (GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().xDirection<0 & shotDir.x<0) 
        | (GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().yDirection>0 & shotDir.y>0) 
        | (GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().yDirection<0 & shotDir.y<0)){
            shotSpeed += 4;
        }
        //changes the speed of the bullet to the shotspeed
        bulletPhysics.velocity = shotDir * shotSpeed;
    }
    void OnTriggerEnter2D(Collider2D thing)
    {
        //if bullet hits player do damage
        if(thing.tag == "Player"){
            thing.GetComponent<PlayerAttributes>().updateHealth(-damage);
            Destroy(gameObject);
        }
    }
}
