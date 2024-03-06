using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfaceTest
{
   public class DestroyEnenmy : MonoBehaviour, Ishootable //Implments the Ishootable interface
{

   int health = 3;
   [SerializeField] private SpriteRenderer sp; //Refernece to the SpriteRenderer of the enemey
   [SerializeField] AudioManger am;
  

   public void DealDamage(int a) // New method to deal damage to the object
   {
     health -= a;
     StartCoroutine(redFlash()); //Calls the IEnumerator method below

     if(health <=0 )
     {
      am.EnemeySound();
      Destroy(gameObject);
     }
   }

   IEnumerator redFlash() //Deals with the enemey flashing red when hit by a bullet and waits before turning back to white
   {
      sp.color = Color.red;
      yield return new WaitForSeconds(0.1f);
      sp.color = Color.white;
   }
}
}

