using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    public GameObject XpOrb;
    public GameObject heart;
    public Transform EnemyLocation;
    public float enemyHealth = 10;
    public bool dead = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
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
