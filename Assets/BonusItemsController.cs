using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BonusItemsController : MonoBehaviour
{
    public List<ShopItem> items;

    public GameObject[] bonusItems;

    public GameObject[] itemsUi;

    public Text[] itemsAmount;

    public WaterController water;

    void Start(){
        items = new List<ShopItem>();

        items.Add(new ShopItem{name="Bomb", price=150});
        items.Add(new ShopItem{name="Hydrant", price=250});
        items.Add(new ShopItem{name="BombPrime", price=450});

        updateUi();
    }

    void updateUi(){
        bool canAtLeastOne=false;
        for(int i=0; i<items.Count; i++){
            if(items[i].canUse()){
                itemsAmount[i].text = items[i].amount().ToString();
                canAtLeastOne=true;
            }
            else{
                itemsUi[i].gameObject.SetActive(false);
            }
        }

        if(!canAtLeastOne){
            gameObject.SetActive(false);
        }
    }

    public void Use(int id){
        if(! items[id].canUse()){
            return;
        }

        items[id].use();

        updateUi();

        var instance = Instantiate(bonusItems[id], bonusItems[id].transform.position, bonusItems[id].transform.rotation) as GameObject;

        if(id == 2){
            instance.gameObject.GetComponent<BonusWaterRocket>().water = this.water;
        }
        else if(id == 1){
            instance.gameObject.GetComponent<BonusHydrant>().water = this.water;
        }
    }
}
