using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InterfaceTest //Put into a namespace so other classes can access it
{
    public interface Ishootable
    {
        void DealDamage(int a); //Method that other classes must implement if using the interface
    }


}
