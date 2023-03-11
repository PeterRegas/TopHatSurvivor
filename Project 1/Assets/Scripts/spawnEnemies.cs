using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{   
    //rate enemies spawn
    double spawnRate;
    int i = 0;
    int j = 0;
    //gameobject for regular enemy
    public GameObject enemy;
    //gameobject for boss
    public GameObject boss;

    // Update is called once per frame
    void FixedUpdate()
    {
        //spawn rate formula
        spawnRate = 10 /  ((double)GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().level * 0.04);
        i++;
        //spawn enemies at max speed after player is level 8
        if(GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().level>=8){
            j=100;
        }
        //spawn enemy
        if(i>=spawnRate){
            j++;
            //choose spawn location
            Vector2 spawn = Random.insideUnitCircle.normalized * 30;
            spawn.x += transform.position.x;
            spawn.y += transform.position.y;
            //create the enemy
            Instantiate(enemy, new Vector3(spawn.x, spawn.y, 0), transform.rotation);
            i=0;
            //start spawning bosses after player is level 5
            if(j>=25 & GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().level>=5){
                Instantiate(boss, new Vector3(spawn.x, spawn.y, 0), transform.rotation);
                j=0;
            }
        }
        
    }
}
