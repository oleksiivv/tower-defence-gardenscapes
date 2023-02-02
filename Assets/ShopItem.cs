using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopItem
{
    public string name;

    public int price;

    public bool buy(){

        if(PlayerPrefs.GetInt("coins")>=price){
            PlayerPrefs.SetInt("ShopItem@"+this.name, PlayerPrefs.GetInt("ShopItem@"+this.name, 0)+1);

            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins")-price);

            return true;
        }
        return false;
    }

    public void buyForFree()
    {
        PlayerPrefs.SetInt("ShopItem@" + this.name, PlayerPrefs.GetInt("ShopItem@" + this.name, 0) + 1);
    }

    public bool canUse(){
        return PlayerPrefs.GetInt("ShopItem@"+this.name, 0)>0;
    }

    public int amount(){
        return PlayerPrefs.GetInt("ShopItem@"+this.name, 0);
    }

    public bool use(){
        PlayerPrefs.SetInt("ShopItem@"+this.name, PlayerPrefs.GetInt("ShopItem@"+this.name, 0)-1);

        return canUse();
    }
}
