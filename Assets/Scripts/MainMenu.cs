using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Script that deals with what the buttons do on the main menu/Timer over screen
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
        print("Game Quit");
    }

    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
   
}
