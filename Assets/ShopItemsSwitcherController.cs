using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopItemsSwitcherController : MonoBehaviour
{
    public GameObject[] shopItems;

    public GameObject[] shopItemsUi;

    public Text[] itemPrices;

    public Text[] itemAmounts;

    public ShopController shopController;

    [HideInInspector]
    public int current=0;

    void Start(){
        //PlayerPrefs.SetInt("coins", 3000);
        hideAll();
        show(current);
    }

    public void Next(){
        current++;
        if(current>=shopItems.Length){
            current=0;
        }

        hideAll();
        show(current);
    }

    public void Prev(){
        current--;
        if(current<0){
            current=shopItems.Length-1;
        }

        hideAll();
        show(current);
    }

    void show(int n){
        shopItems[n].SetActive(true);
        shopItemsUi[n].SetActive(true);

        updateUI(n);
    }

    public void updateUI(int n){
        itemAmounts[n].text = "x"+PlayerPrefs.GetInt("ShopItem@"+shopController.shopItems[n].name,0).ToString();
        itemPrices[n].text = shopController.shopItems[n].price.ToString();
    }

    void hideAll(){
        foreach(var item in shopItems){
            item.SetActive(false);
        }
        foreach(var item in shopItemsUi){
            item.SetActive(false);
        }
    }

}
