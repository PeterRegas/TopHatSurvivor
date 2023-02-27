using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[System.Serializable]
public class SaveState
{
    public int health;
    public int score;
    public int level;
    public float experience;


    public SaveState()
    {
        health = 100;
        score = 0;
        level = 1;
        experience = 0.0f;
    }
    
    public SaveState(int health, int score, int level, float experience)
    {
        this.health = health;
        this.score = score;
        this.level = level;
        this.experience = experience;
    }

    


}
