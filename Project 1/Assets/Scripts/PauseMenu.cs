using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;


public class PauseMenu : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject saveObject;
    private TextMeshProUGUI saveText;
    private SaveManager saveManager;

    private void Awake()
    {
        saveManager = FindObjectOfType<SaveManager>();
        saveText = saveObject.GetComponent<TextMeshProUGUI>();
        saveText.text = "Save";
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        saveText.text = "Save";
        Time.timeScale = 0f;
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void saveButtonPressed()
    {
        saveManager.savePlayerStats();
        saveText.text = "Saved!";
    }
}
