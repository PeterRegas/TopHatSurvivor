using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float shotSpeed = 0.1f;
    public int range = 1;
    public int damage = 5;
    public Rigidbody2D bulletPhysics;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject,range);
         Vector2 shotDir = Random.insideUnitCircle.normalized* 2;
         shotDir = shotDir/shotDir.magnitude;
         bulletPhysics.rotation = Mathf.Atan2(shotDir.y, shotDir.x) * Mathf.Rad2Deg;
         bulletPhysics.velocity = shotDir * shotSpeed;
        
    }
    void OnTriggerEnter2D(Collider2D thing)
    {
        if(thing.tag == "Player"){
            thing.GetComponent<PlayerAttributes>().updateHealth(-10);
            Destroy(gameObject);
        }
    }
}
