using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfaceTest //Put into the same namespace to allow access to the 
{
     public class Bullet : MonoBehaviour
{   
    int damageAmount =  1; //How much damanage the bullet will do
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ishootable col = collision.gameObject.GetComponent<Ishootable>(); //Refers to the interface used via the script name

        if(col != null)
        {
            col.DealDamage(damageAmount);
            Destroy(gameObject);
        }
        
    }
}
}

