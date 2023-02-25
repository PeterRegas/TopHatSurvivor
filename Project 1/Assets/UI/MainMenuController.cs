using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    UIDocument mainMenuDoccument;
    public Button startButton, instructionsButton, settingsButton;

    
    // Start is called before the first frame update
    void Start()
    {
        mainMenuDoccument = GetComponent<UIDocument>();
        var root = mainMenuDoccument.rootVisualElement;

        startButton = root.Q<Button>("StartButton");
        instructionsButton = root.Q<Button>("InstructionsButton");
        settingsButton = root.Q<Button>("SettingsButton");

        startButton.RegisterCallback<ClickEvent>(StartButtonPressed);
    }

    public void StartButtonPressed(ClickEvent click)
    {
        Debug.Log("Clicked");
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
}
