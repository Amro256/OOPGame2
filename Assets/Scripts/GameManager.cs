using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static int coins, lives;
    public static Vector3 lastPos;
    static UI gameUI; //Refernece to UI script


   private void Awake()
   {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        gameUI = FindObjectOfType<UI>(); //Refernece to the UI scripts
        coins = 0;
        lives = 3;
        gameUI.LiveCounter(); //Updates the live counter UI
        gameUI.CoinCounter(); // Updates the Coin Counter UI
   }

    //Code for coins
    public static void AddCoin(int CoinAmount) //Method to add coins
    {
        coins += CoinAmount;

        //If total amount of coins are collected then level complete 
        if(coins == 20)
        {  
            //Check the game state and call the level complete state
            gameUI.CheckingGameState(UI.GameState.GameWin);
        }
        gameUI.CoinCounter();
    }

    //Code to deal with lvies
    public static void Lives(int livePoints)
    {
        lives += livePoints;
        if(lives < 0)
        {
            //Call the GameOver State
            gameUI.CheckingGameState(UI.GameState.GameOver);
        }
        else
        {
            gameUI.LiveCounter(); 
        }
        
    }
    
    public static void CheckpointPosition(GameObject bulb)
    {
        lastPos = bulb.transform.position;
        //Need an array to check all objects that have the checkpoint Script attached to it
        Checkpoints[] allCP = FindObjectsOfType<Checkpoints>();
        //For each loop that will check each checkpoint
        foreach(Checkpoints cp in allCP)
        {
            if(cp != bulb.GetComponent<Checkpoints>()) 
            {
                //Call the change bulb colour method from checkpoint script
                cp.ChangeBulbColour();
            }
        }
    }
    
   
}
