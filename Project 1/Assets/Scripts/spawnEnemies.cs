using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemies : MonoBehaviour
{   
    double spawnRate;
    int i = 0;
    int j = 0;

    public GameObject enemy;
    public GameObject boss;

    // Update is called once per frame
    void FixedUpdate()
    {
        spawnRate = 10 /  ((double)GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().level * 0.03);
        i++;
        if(i>=spawnRate){
            j++;
            Vector2 spawn = Random.insideUnitCircle.normalized * 30;
            spawn.x += transform.position.x;
            spawn.y += transform.position.y;
            Instantiate(enemy, new Vector3(spawn.x, spawn.y, 0), transform.rotation);
            i=0;
            if(j>=25 & GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttributes>().level>=5){
                Instantiate(boss, new Vector3(spawn.x, spawn.y, 0), transform.rotation);
                j=0;
            }
        }
        
    }
}
