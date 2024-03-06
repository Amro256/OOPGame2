using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{   
    //Intially going to use interface, but bullets would kill the player
    int healthPoints = 3;
    private SpriteRenderer ren;


   void Start()
   {
        ren = GetComponent<SpriteRenderer>();
       
   }
  
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            DealDamage(1);
            StartCoroutine(Damange());
            Debug.Log("test collide");
        }
    }
    void DealDamage(int a)
    {
        healthPoints -= a;

        if(healthPoints <0)
        {
            GameManager.Lives(-1);
            //Respawn player back at checkpoint position
            gameObject.transform.position = GameManager.lastPos;
        }
    }

    IEnumerator Damange()
    {
        ren.enabled = false;
        yield return new WaitForSeconds(0.1f);
        ren.enabled = false;
        yield return new WaitForSeconds(0.1f);
        ren.enabled = true;
    }


}



