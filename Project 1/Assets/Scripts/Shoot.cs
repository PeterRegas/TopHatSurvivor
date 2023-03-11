using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //where the bullet fires from
    public Transform shootSpot;
    //bullet prefab for standard shot
    public GameObject Bullet;
    //random direction bullet prefab for when player hits level 5
    public GameObject BulletRandom;
    //fire rate of bullets
    public float fireRate;

    public float baseFire;
    int i = 0;
    int j = 0;

    void Start(){
        baseFire = fireRate;
    }
    void FixedUpdate()
    {
        i++;
        j++;
        //increase firerate based on level
        if(gameObject.tag == "Player" & fireRate >= 0 &GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().level>1){
            fireRate = baseFire - (6*GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().level);
        }
        //fire a random direction shot once every 5 shots after level 4
        if(gameObject.tag == "Player" & GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().level>4 & j>=fireRate*5){
            FireRandom();
            j=0;
        }
        if(i>=fireRate){
            Fire();
            i=0;
        }
        
    }
    void Fire(){
        //create the bullet
        Instantiate(Bullet, shootSpot.position, shootSpot.rotation);
    }
    void FireRandom(){
        //create the random bullet
        Instantiate(BulletRandom, shootSpot.position, shootSpot.rotation);
    }
}
