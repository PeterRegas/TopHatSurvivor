using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[System.Serializable]
public class PlayerAttributes : MonoBehaviour
{

    public int health, score, level;
    public float experience;
    private const float baseExperience = 100f;
    private const float levelUpExponent = 0.7f; //Make this larger to make it harder to level up every level
    [SerializeField] Slider healthSlider;
    [SerializeField] Slider experienceSlider;
    [SerializeField] TextMeshProUGUI levelNum;
    private SaveManager saveManager;
    
   

    // Start is called before the first frame update
    void Start()
    {
        //Loads data based on save file
        saveManager = FindObjectOfType<SaveManager>();
        SaveState saveState = saveManager.playerStats;
        health = saveState.health;
        score = saveState.score;
        experience = saveState.experience;
        level = saveState.level;

        updateXP(0);
        updateHealth(0);
        levelNum.text = "Level " + level.ToString();
    }

    // Update is called once per frame
    void Update()
    {


        levelNum.text = "Level " + level.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("enemy"))
        {
            updateHealth(-20);
        }
        if (collision.gameObject.CompareTag("xp"))
        {
            updateXP(20);
        }
    }

    //changes player health based on a given value
    //Useful for when enemy hits, give a negative value
    //Useful for when player picks up health, give postive value
    private void updateHealth(int value)
    {
        health += value;
        healthSlider.value = health;
    }

    //Updated player XP and level based on how much XP was picked up
    //XP object needs tag "xp"
    private void updateXP(float value)
    {
        experience += value;
        float totalExperienceRequired = baseExperience * Mathf.Pow(level, levelUpExponent);
        if (experience >= totalExperienceRequired)
        {
            level+= Mathf.FloorToInt(experience /totalExperienceRequired);
            experience -= totalExperienceRequired * Mathf.FloorToInt(experience / totalExperienceRequired);
        }
        Debug.Log(experience);
        totalExperienceRequired = baseExperience * Mathf.Pow(level, levelUpExponent);
        float percentageProgress = (experience / totalExperienceRequired) * 100.0f;
        experienceSlider.value = percentageProgress;
    }


}
