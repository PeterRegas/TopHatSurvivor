using UnityEngine;
using System.IO;

public class JSONLoaderSaver
{
    public static void SaveAsJSON(string savePath, string filename, SaveState playerStats)
    {

        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
        string json = JsonUtility.ToJson(playerStats);
        File.WriteAllText(savePath + filename, json);
    }

    public static SaveState LoadFromJSON(string savePath, string filename)
    {
        if (File.Exists(savePath + filename))
        {
            string json = File.ReadAllText(savePath + filename);
            SaveState playerStats = JsonUtility.FromJson<SaveState>(json);
            return playerStats;
        }
        Debug.Log("Unable to load from file: " + savePath + filename);
        return null;
    }
}