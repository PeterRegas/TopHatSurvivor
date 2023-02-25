using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    [SerializeField] float movementSpeed = 8f;
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
        float xDirection = Input.GetAxis("Horizontal");
        float yDirection = Input.GetAxis("Vertical");
        if(xDirection>0){
            //animator.SetBool("walk right", true);
        }
        else{
            //animator.SetBool("walk right", false);
        }
        if(xDirection<0){
            //animator.SetBool("walk left", true);
        }
        else{
            //animator.SetBool("walk left", false);
        }
        if(yDirection<0){
            //animator.SetBool("walk down", true);
        }
        else{
            //animator.SetBool("walk down", false);
        }
        if(yDirection>0){
            //animator.SetBool("walk up", true);
        }
        else{
            //animator.SetBool("walk up", false);
        }
        Vector3 direction = (targplayer.position - transform.position).normalized;
        move = direction;
        
    }
    void FixedUpdate() {
        enemyPhysics.velocity = new Vector2(move.x,move.y) * movementSpeed;
    }
}
