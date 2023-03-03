using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InstructionsButton : MonoBehaviour
{
    [SerializeField] GameObject page1;
    [SerializeField] GameObject page2;
    

   
    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void goNextPage()
    {
        page1.SetActive(false);
        page2.SetActive(true);
    }
    public void goPrevPage()
    {
        page1.SetActive(true);
        page2.SetActive(false);
    }
}
