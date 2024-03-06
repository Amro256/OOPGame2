using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCAI : MonoBehaviour
{ 
    enum AiState{ Idle, Attacking }; //enum that stores the AI states 
    enum AiMoveDirection{Left, Right, Stop}; // AI the stores the move direction of the AI
    NPCController npcController; //Reference to the NPc Controller Script
    AiState aiState;
    GameObject playerTarget;
    float playerDistanceX;
    float playerDistanceY;
    float attackRange = 3.0f;
    private Animator ani; //Refernece to the animator componenet
    AiMoveDirection aiMoveDir;
    float enemeyTimer = 0f;
    float decisionWait = 0.5f;
    void Start()
    {
        npcController = GetComponent<NPCController>(); //Assigning it to the correct component
        playerTarget = GameObject.FindGameObjectWithTag("Player");
        ani = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTarget != null) //Checks if the player has not been destroyed 
        {
            CheckPlayerRangeAndUpdateAIState(); //Calls the method that will
            if(aiState == AiState.Idle)
            {
                StopMoving();
            }
            else if(aiState == AiState.Attacking)
            {
                MoveTowardsPlayer(); 
            }
        }
    }

    void CheckPlayerRangeAndUpdateAIState()
    {
        playerDistanceX = playerTarget.transform.position.x - transform.position.x;  //Will give the X distance between the player and NPC
        playerDistanceY = playerTarget.transform.position.y - transform.position.y;
        
        if((Mathf.Abs(playerDistanceX) < attackRange) && (Mathf.Abs(playerDistanceY) < attackRange)) //Mathsf abs takes our input and gives a positive integer
        {
            //Player is within range to attack on A axis and y axis 
            //Set our Enum for Ai state to be attack
            ani.Play("SlimeMovement"); //Plays the movement animation
            aiState = AiState.Attacking;
        }
        else
        {
            //Player is out of range, so we want ai state to be idle 
            ani.Play("SlimeAni"); //Plays the Idle Animation
            aiState = AiState.Idle;
        }
    }

    void MoveTowardsPlayer()
    {
        //Code to make NPC move towards player
        if(DecisionTimer())
        {
                //Choose a move decision when timer is reached 
                List<AiMoveDirection> possibleMove = new List<AiMoveDirection>();

                if(playerDistanceX <= 0)
                {
                    possibleMove.Add(AiMoveDirection.Left); //Add the left movementDirection to the list
                }
                else if (playerDistanceX > 0)
                {
                    possibleMove.Add(AiMoveDirection.Right); //Add the right movementDirection to the list
                }
                int randomMove = Random.Range(0, possibleMove.Count);
                aiMoveDir = possibleMove[randomMove];

        }

        //Apply movement selected by the NPC
        switch(aiMoveDir)
        {
            case AiMoveDirection.Left:
            MoveLeft();
            break;
            case AiMoveDirection.Right:
            MoveRight();
            break;
        }
    }

     bool DecisionTimer() //Method that deals with a timer that will help the NPC to make a moveDirection
     {
        enemeyTimer += Time.deltaTime; //TImer will increase over time
        if(enemeyTimer > decisionWait)
        {
            enemeyTimer = 0f;
            return true; //Will be true if the timer reaches time 
        }
        else
        {
            return false;
        }
     }

    //Methods that deals with the AI left, right and stoping movement 
    void MoveLeft()
    {
        npcController.ControlNPC(-1f, 0f);
    }

    void MoveRight()
    {
        npcController.ControlNPC(1f, 0f);
    }

    void StopMoving()
    {
        npcController.ControlNPC(0f, 0f);
    }

}
