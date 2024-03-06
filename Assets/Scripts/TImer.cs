using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class TImer : MonoBehaviour
{
    float TimeLimit = 90; //Time Limit for the player to collect coins
    [SerializeField] TextMeshProUGUI TimerUI;
    float TimePassed;
    
    void Update()
    {
        TimePassed += Time.deltaTime; 

        if(TimePassed > TimeLimit)
        {
            //Send player back to the Time Over Screen if they run out of time
            SceneManager.LoadScene("TimerOver");
        }

        DisplayTimerUI(); //Calls the method to display and updates UI
    }


    void DisplayTimerUI()
    {
        float TimeLeft = TimeLimit - TimePassed;
        //Calculate Minutues 
        float mins = Mathf.FloorToInt(TimeLeft / 60); //FloorToInt rounds the mins down to the nearest whole number
        //Calculate seconds
        float secs = TimeLeft - mins * 60;

        //Update Timer UI
        TimerUI.text = string.Format("{0:00}:{1:00}", mins, secs); 
    }
}
