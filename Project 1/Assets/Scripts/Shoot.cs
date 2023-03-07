using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //where the bullet fires from
    public Transform shootSpot;
    public GameObject Bullet;
    public GameObject BulletRandom;
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
        if(gameObject.tag == "Player" & fireRate >= 0 &GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().level>1){
            fireRate = baseFire - (6*GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().level);
        }
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
        Instantiate(Bullet, shootSpot.position, shootSpot.rotation);
    }
    void FireRandom(){
        Instantiate(BulletRandom, shootSpot.position, shootSpot.rotation);
    }
}
