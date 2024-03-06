using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SignInteraction : MonoBehaviour
{
    [SerializeField] bool inRange;
    [SerializeField] GameObject UIButtonPrompt;
    [SerializeField] GameObject TextBubble;

    void Start()
    {
        //Set UI elments to false when the game starts up
        UIButtonPrompt.SetActive(false);
        TextBubble.SetActive(false);
    }

    void Update()
    {
        if(inRange) //Checks if the player is in range 
        {
            if(Input.GetKeyDown(KeyCode.E)) //Checks if the player presses E if in range 
            {
                //Set Ui to active
                UIButtonPrompt.SetActive(false);
                Time.timeScale = 0; //Freees everything
                TextBubble.SetActive(true);
            }
            else if(Input.GetKeyDown(KeyCode.B)) //Allows the player to close down the text bubble UI
            {
                TextBubble.SetActive(false);
                Time.timeScale = 1f; 
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision) 
    {
       if(collision.gameObject.CompareTag("Player"))
       {
            //Chekcs if the collision is with the player and is range. If so, the UIButtonPrompt will appear
            inRange = true;
            UIButtonPrompt.SetActive(true);
       } 
    }

    void OnTriggerExit2D(Collider2D collision) 
    {
        inRange = false;
        UIButtonPrompt.SetActive(false);
        TextBubble.SetActive(false);
    }


}
