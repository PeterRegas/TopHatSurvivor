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
        Vector2 shotDir = Random.insideUnitCircle;
        shotDir.Normalize();
        bulletPhysics.rotation = Mathf.Atan2(shotDir.y, shotDir.x) * Mathf.Rad2Deg;
        
        if((GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().xDirection>0 & shotDir.x>0) 
        | (GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().xDirection<0 & shotDir.x<0) 
        | (GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().yDirection>0 & shotDir.y>0) 
        | (GameObject.FindGameObjectWithTag("Player").GetComponent<Movement>().yDirection<0 & shotDir.y<0)){
            shotSpeed += 4;
        }
        bulletPhysics.velocity = shotDir * shotSpeed;
    }
    void OnTriggerEnter2D(Collider2D thing)
    {
        if(thing.tag == "Player"){
            thing.GetComponent<PlayerAttributes>().updateHealth(-damage);
            Destroy(gameObject);
        }
    }
}
