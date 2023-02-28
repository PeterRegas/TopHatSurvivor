using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float movementSpeed = 8f;
    [SerializeField] private SpriteRenderer sprite;
    public Rigidbody2D enemyPhysics;
    Vector2 move;
    public Transform targplayer;
    // Start is called before the first frame update
    void Start()
    {
        targplayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {       
        Vector3 direction = (targplayer.position - transform.position).normalized;
        move = direction;
        if(direction.x<0){
            sprite.flipX=true;
        }
        else{
            sprite.flipX=false;
        }
        
    }
    void FixedUpdate() {
        enemyPhysics.velocity = new Vector2(move.x,move.y) * movementSpeed;
    }
}
