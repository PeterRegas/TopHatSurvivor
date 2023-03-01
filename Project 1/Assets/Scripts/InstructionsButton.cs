using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsButton : MonoBehaviour
{
    private GameObject page1;

    private void Awake()
    {
        page1 = GameObject.Find("Page1");
    }
    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void goNextPage()
    {
        page1.SetActive(false);
    }
    public void goPrevPage()
    {

    }
}
