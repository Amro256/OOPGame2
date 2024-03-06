using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public enum GameState{GamePaused, GameResume, GameOver, GameWin}; //Enum that holds the states that the game can be in
    [SerializeField] GameObject PausePannel, GameOverPannel, VictoryPannel; //Allows the GamePannels to be dropped in the inspector
    [SerializeField] private bool isGamePaused; // Bool to check if the game is pasued or not
    [SerializeField] TextMeshProUGUI coinText, livesText; //Allows the text for the coin/live GUI to be dropped into the inspector 
    public GameState currentGameState; //Will check the current game state
    
    void Start()
    {
        //Set all panels to false when the game starts 
        PausePannel.SetActive(false);
        GameOverPannel.SetActive(false);
        VictoryPannel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentGameState == GameState.GamePaused)
            {
                CheckingGameState(GameState.GameResume); //Resume the game if the game is paused 
            }
            else
            {   
                CheckingGameState(GameState.GamePaused);
            }
        }
    }

    public void CheckingGameState(GameState newState) //Method that iwll check the game states enum and calls the methods for each state
    {
        currentGameState = newState;
        switch (currentGameState)
        {
            case GameState.GamePaused:
            PauseGame();
            break;
            case GameState.GameResume:
            ResumeGame();
            break;
            case GameState.GameOver:
            GameOver();
            break;
            case GameState.GameWin:
            ActClear();
            break;
        }
    }

    //Methods
     public void PauseGame()
    {
        PausePannel.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        PausePannel.SetActive(false);
        isGamePaused = false;
        Time.timeScale = 1f;
    }

    public void GameOver()
    {
        GameOverPannel.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0f;
    }
    public void ActClear()
    {
        VictoryPannel.SetActive(true);
        isGamePaused = true;
        Time.timeScale = 0f;
    }
    public void Restart()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void CoinCounter()
    {
        coinText.text = GameManager.coins.ToString(); //Converts the coin int into a string 

    }

    //Add method for lives
    public void LiveCounter()
    {
        livesText.text = GameManager.lives.ToString(); //Converts lives int into a string

    }
}
