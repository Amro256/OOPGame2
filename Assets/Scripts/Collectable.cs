using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Collectable : MonoBehaviour //Parent class for the collectable
{

    protected void OnCollisionEnter2D(Collision2D collision)
    {
        GiveItem();
        Destroy();
    }
    
    protected virtual void GiveItem() //Protected virtual allows the other classes to override this method.
    {
        print("Test");
    }

    protected void Destroy()
    {
        Destroy(gameObject);
    }
}
