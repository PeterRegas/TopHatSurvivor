using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    UIDocument mainMenuDoccument;
    public Button startButton, instructionsButton, quitButton, loadButton;
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
        quitButton = root.Q<Button>("QuitButton");
        loadButton = root.Q<Button>("LoadButton");
        startButton.RegisterCallback<ClickEvent>(StartButtonPressed);
        loadButton.RegisterCallback<ClickEvent>(loadButtonPressed);
        instructionsButton.RegisterCallback<ClickEvent>(instructionsButtonPressed);
        quitButton.RegisterCallback<ClickEvent>(quitButtonPressed);
    }


    public void StartButtonPressed(ClickEvent click)
    {
        SaveState newSave = new SaveState();
        Debug.Log(newSave.health);
        saveManager.playerStats = newSave;
        Debug.Log("Start Pressed");
        SceneManager.LoadScene("TophatSurvivor");
    }
    void instructionsButtonPressed(ClickEvent click)
    {
        SceneManager.LoadScene("InstructionsScene");
    }

    void quitButtonPressed(ClickEvent click)
    {
        Debug.Log("quit");
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }
    void loadButtonPressed(ClickEvent click)
    {
        saveManager.loadPlayerStats();
        SceneManager.LoadScene("TophatSurvivor");
        
    }
}
