using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] AudioManger am;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player") //Checks if the object colliding with the killZone is the player
        {
            am.KillZoneSound();
            //Code to return player to last checkpoitn
            collision.gameObject.transform.position = GameManager.lastPos;
            GameManager.Lives(-1); //Player loses a life if they touch the kill zone
        }
    }
}
