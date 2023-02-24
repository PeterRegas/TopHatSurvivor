using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{   
    int spawnRate = 50;
    int i = 0;
    int minDist = 10;
    int maxDist = 10;
    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        i++;
        if(i==spawnRate){
            Instantiate(enemy, new Vector3(Random.Range(minDist, maxDist), Random.Range(minDist, maxDist), 0), transform.rotation);
            i=0;
        }
        
    }
}
