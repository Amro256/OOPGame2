using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoints : MonoBehaviour
{
    GameObject bulb;
    [SerializeField] AudioManger am; //Reference to the Audio Manager

    void Start()
    {
        //Find the bulb component attached the the checkpoint base gameObject 
        bulb = transform.Find("Bulb").gameObject;
    }
    
    

    void OnTriggerEnter2D(Collider2D collision)
{
    if(collision.tag == "Player") 
    {
        am.CheckpointSound();
        GameManager.CheckpointPosition(gameObject); //Will saves the player's position to checkpoints position
        bulb.GetComponent<SpriteRenderer>().color = Color.green; //Change the bulb colour to green
        Debug.Log("Checkpoint activated");
    }
}

    public void ChangeBulbColour() //is public as the manager will need access to it
    {
        //Change bulb colour back if player passes another checkpoint
        bulb.GetComponent<SpriteRenderer>().color = Color.red;
    }
   

}
