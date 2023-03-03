using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class PlayerAttributes : MonoBehaviour
{

    public float health, score, level;
    public float experience;
    private const float baseExperience = 100f;
    private const float levelUpExponent = 0.7f; //Make this larger to make it harder to level up every level
    [SerializeField] Slider healthSlider;
    [SerializeField] Slider experienceSlider;
    [SerializeField] TextMeshProUGUI levelNum;
    public SaveManager saveManager;
    public SaveState saveState;


    // Start is called before the first frame update
    void Start()
    {
       
        //Loads data based on save file
        saveManager = FindObjectOfType<SaveManager>();
        saveState = saveManager.playerStats;

        //saveState = saveManager.playerStats;

        //Sets the current attributes based on the a saveState class
        health = saveState.health;
        score = saveState.score;
        level = saveState.level;
        experience = saveState.experience;
        updateXP(0);
        updateHealth(0);
        levelNum.text = "Level " + saveState.level.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        //constantly update the player attributes based on the saveState class attributes. 
        health = saveState.health;
        score = saveState.score;
        level = saveState.level;
        experience = saveState.experience;
        saveState = saveManager.playerStats;
        updateXP(0);
        updateHealth(0);

        //Change player level based on 
        levelNum.text = "Level " + saveState.level.ToString();

       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            if(collision.GetComponent<enemy>().dead==false){
                updateHealth(-20);
            }
            
        }
        if (collision.gameObject.CompareTag("xp"))
        {
            updateXP(20);
        }
        if (collision.gameObject.CompareTag("hp"))
        {
            updateHealth(20);
        }
    }

    //changes player health based on a given value
    //Useful for when enemy hits, give a negative value
    //Useful for when player picks up health, give postive value
    public void updateHealth(int value)
    {
        saveState.health += value;
        healthSlider.value = saveState.health;
    }

    //Updated player XP and level based on how much XP was picked up
    //XP object needs tag "xp"
    private void updateXP(float value)
    {
        saveState.experience += value;
        float totalExperienceRequired = baseExperience * Mathf.Pow(saveState.level, levelUpExponent);
        if (saveState.experience >= totalExperienceRequired)
        {
            saveState.level += Mathf.FloorToInt(saveState.experience /totalExperienceRequired);
            saveState.experience -= totalExperienceRequired * Mathf.FloorToInt(saveState.experience / totalExperienceRequired);
        }
        // Debug.Log("Experience:" + saveState.experience);
        totalExperienceRequired = baseExperience * Mathf.Pow(level, levelUpExponent);
        float percentageProgress = (experience / totalExperienceRequired) * 100.0f;
        experienceSlider.value = percentageProgress;
    }


}
