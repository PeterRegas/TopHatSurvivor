using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{   
    int spawnRate = 500;
    int i = 0;

    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        i++;
        if(i==spawnRate){
            Vector2 spawn = Random.insideUnitCircle * 20;
            spawn.x += transform.position.x;
            spawn.y += transform.position.y;
            Instantiate(enemy, new Vector3(spawn.x, spawn.y, 0), transform.rotation);
            i=0;
        }
        
    }
}
