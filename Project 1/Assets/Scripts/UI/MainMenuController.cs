using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    UIDocument mainMenuDoccument;
    public Button startButton, instructionsButton, settingsButton, loadButton;
    private SaveManager saveManager ;
    public bool isLoad = false;
    

    // Start is called before the first frame update
    void Awake()
    {
        saveManager = FindObjectOfType<SaveManager>();
        mainMenuDoccument = GetComponent<UIDocument>();
        var root = mainMenuDoccument.rootVisualElement;

        startButton = root.Q<Button>("StartButton");
        instructionsButton = root.Q<Button>("InstructionsButton");
        settingsButton = root.Q<Button>("SettingsButton");
        loadButton = root.Q<Button>("LoadButton");
        startButton.RegisterCallback<ClickEvent>(StartButtonPressed);
        loadButton.RegisterCallback<ClickEvent>(loadButtonPressed);
    }



    public void StartButtonPressed(ClickEvent click)
    {
        SaveState newSave = new SaveState();
        Debug.Log(newSave.health);
        saveManager.playerStats = newSave;
        Debug.Log("Start Pressed");
        SceneManager.LoadScene("TophatSurvivor");
    }
    void InstructionsButtonPressed()
    {
        SceneManager.LoadScene("TophatSurvivor");
    }

    void SettingsButtonPressed()
    {
        SceneManager.LoadScene("TophatSurvivor");
    }
    void loadButtonPressed(ClickEvent click)
    {
        saveManager.loadPlayerStats();
        SceneManager.LoadScene("TophatSurvivor");
        
    }
}
