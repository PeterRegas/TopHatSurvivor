using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    //enemy animator
    [SerializeField] private Animator animator = null;
    //xp drops
    public GameObject XpOrb;
    //health drops
    public GameObject heart;
    //enemy location
    public Transform EnemyLocation;
    //set enemys health
    public float enemyHealth = 10;
    public bool dead = false;

    //when enemy is hit after they take damage check if they are dead
    //if so remove enemy and randomly drop health or xp
    public void Hit(float damage){
        enemyHealth -= damage;
        if(enemyHealth <= 0){
            
            animator.SetBool("dead", true);
            int i = Random.Range(1, 24);
            if(dead==false){
                if(i==1){
                    Instantiate(heart, EnemyLocation.position, EnemyLocation.rotation);
                    dead = true;
                }
                else{
                    Instantiate(XpOrb, EnemyLocation.position, EnemyLocation.rotation);
                    dead = true;
                }
            }
            
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
