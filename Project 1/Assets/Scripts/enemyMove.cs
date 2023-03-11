using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    //enemy move speed
    public float movementSpeed = 8f;
    //sprite for the enemy for animations
    [SerializeField] private SpriteRenderer sprite;
    //rigid body for physics
    public Rigidbody2D enemyPhysics;
    Vector2 move;
    //player so it can move towards them
    public Transform targplayer;
    // Start is called before the first frame update
    void Start()
    {
        //finds the player
        targplayer = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {       
        //walks towards the player
        Vector3 direction = (targplayer.position - transform.position).normalized;
        move = direction;
        //flip sprite to face player
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
