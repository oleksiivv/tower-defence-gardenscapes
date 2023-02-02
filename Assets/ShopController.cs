using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopController : MonoBehaviour
{
    public ShopItemsSwitcherController shopItemsSwitcher;

    [HideInInspector]
    public List<ShopItem> shopItems;

    public Text coins;

    public ParticleSystem buyEffect;

    void Start(){
        coins.GetComponent<Text>().text = PlayerPrefs.GetInt("coins", 0).ToString();

        shopItems = new List<ShopItem>();

        shopItems.Add(new ShopItem{name="Bomb", price=150});
        shopItems.Add(new ShopItem{name="Hydrant", price=250});
        shopItems.Add(new ShopItem{name="BombPrime", price=450});
    }

    public void buy(){
        if(shopItems[shopItemsSwitcher.current].buy()){
            onSuccessfulBuy();
        }
    }

    private void onSuccessfulBuy(){
        buyEffect.Play();

        coins.text = PlayerPrefs.GetInt("coins", 0).ToString();

        shopItemsSwitcher.updateUI(shopItemsSwitcher.current);
    }
}
