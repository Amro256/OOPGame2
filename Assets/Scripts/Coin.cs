using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Coin : Collectable //Coin inherites from the Collectable base class. Reads as Coin is a Collectable
{
   [SerializeField] int CoinAmount = 1;
   [SerializeField] AudioManger am;
    protected override void GiveItem() //Overrides the GiveItem method so the coin has it's own way of doing it
    {
        am.CoinsSound();
        GameManager.AddCoin(CoinAmount); //Coin is added and UI updated by the manager
        print("coin collected");
    }
    
}







