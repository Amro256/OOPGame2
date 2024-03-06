using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
void OnTriggerEnter2D(Collider2D collision) 
{
    if(collision.tag == "Player") //Checks if the collision is with the player
    {
        GameManager.Lives(-1); //Removes a live
        collision.gameObject.transform.position = GameManager.lastPos; //Resets the player back to checkpoint position
    }
}
}
