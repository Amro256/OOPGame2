using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBullet : MonoBehaviour
{

    //Script to destroy the bullet after 3 seconds. Done to prevent the hieratchy from being flooded 
    float destroy = 3f;
    void Start()
    {
        Destroy(gameObject, destroy);
    }
}
