using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    [SerializeField] private Animator animator = null;
    public GameObject XpOrb;
    public Transform EnemyLocation;
    public int enemyHealth = 10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Hit(int damage){
        enemyHealth -= damage;
        if(enemyHealth <= 0){
            animator.SetBool("dead", true);
            Instantiate(XpOrb, EnemyLocation.position, EnemyLocation.rotation);
            Destroy(gameObject, animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}
