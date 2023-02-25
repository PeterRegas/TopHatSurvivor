using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttributes : MonoBehaviour
{

    public int health, score, experience;
    [SerializeField] Slider healthSlider;

    void Awake()
    {
        health = 100;
        score = 0;
        experience = 0;

        healthSlider.value = health;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.gameObject.CompareTag("enemy"))
        {
            updateHealth(-20);
        }
    }

    //reduces enemy health based on the enemy's damage given
    private void updateHealth(int value)
    {
        health += value;
        healthSlider.value =health;
    }
}
