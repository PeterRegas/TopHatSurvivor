using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    public SaveState playerStats = null;
    private static SaveManager instance;
    private string savePath;

    private void Awake()
    {
        
        if(instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;

        }
        

        savePath = Application.persistentDataPath + "/saveData/";
        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
        Debug.Log("Saving to path: " + savePath);

        this.playerStats = new SaveState();
    }

    [ContextMenu("Save playerStats")]
    public void savePlayerStats()
    {
        // save the data
        JSONLoaderSaver.SaveAsJSON(savePath, "playerStats.json", this.playerStats);
    }

    [ContextMenu("Load playerStats")]
    public void loadPlayerStats()
    {
        // load the data
        this.playerStats = JSONLoaderSaver.LoadFromJSON(savePath, "playerStats.json");
    }
}