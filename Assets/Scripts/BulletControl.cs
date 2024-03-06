using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    //Variables 
    [SerializeField] Rigidbody2D bullet; //Reference to the bullet made in game 
    float bulletSpeed = 5;
    float offsetX = 0.9f; //Will offset the bullets so they dont spawn in the centre of the player 
    [SerializeField] AudioManger am;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1")) //when the Left ctrl is pressed the shot is fired 
        {
            
            FireWeapon(); //Calls the FireWeapon method
        }
    }

    void FireWeapon() // new method so that the spaceship can shoot lasers 
    {
        am.BulletSoundEffect();
        Rigidbody2D shot; //creates shot
        shot = Instantiate(bullet, transform.position, transform.rotation); //Creates copy of the bullet prefab
        shot.velocity = transform.right * bulletSpeed; //To move the bulet horizontally - velocity is used  
    }
}
