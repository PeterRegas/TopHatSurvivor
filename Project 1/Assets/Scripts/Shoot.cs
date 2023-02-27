using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    //where the bullet fires from
    public Transform shootSpot;
    public GameObject Bullet;
    public int fireRate;
    int i = 0;

    // Update is called once per frame
    void Update()
    {
        i++;
        if(i>=fireRate){
            Fire();
            i=0;
        }
        
    }
    void Fire(){
        Instantiate(Bullet, shootSpot.position, shootSpot.rotation);
    }
}
