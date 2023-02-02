using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BaseDefender : MonoBehaviour
{
    public int Price {get; set;}
    public Sprite sprite {get;set;}

    public BaseDefender(int price, Sprite sprite){
        this.Price = price;
        this.sprite = sprite;
    }

    public BaseDefender ShowPrice(Text priceLabel){
        priceLabel.text = this.Price.ToString();
        Debug.Log(this.Price.ToString()+"--------------------------------");
        return this;
    }

    public BaseDefender ShowSprite(Image sprite){

        sprite.sprite = this.sprite;
        return this;
    }

    public BaseDefender Set(int price){
        this.Price = price;

        return this;
    }
}
