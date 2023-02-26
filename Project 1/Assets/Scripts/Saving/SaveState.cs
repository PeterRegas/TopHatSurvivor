using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveState : MonoBehaviour
{
    public int health, score, level;
    public float experience;


    public SaveState()
    {
        this.health = 100;
        this.score = 0;
        this.level = 1;
        this.experience = 0.0f;
    }
    public SaveState(int health, int score, int level, float experience)
    {
        this.health = health;
        this.score = score;
        this.level = level;
        this.experience = experience;
    }

    


}
