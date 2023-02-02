using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System.Linq;

public class AllDefendersListController : MonoBehaviour
{
    public Sprite[] defendersSprite;
    public DefendersListController defendersList;
    public List<Image> slots;
    public List<Text> prices;

    public bool infinityLevel = false;

    public int MaxDefendersNumber;

    void Start(){

        if (infinityLevel)
        {
            MaxDefendersNumber += PlayerPrefs.GetInt("NumberOfNewItems");
        }

        for(int i=0; i<slots.Count; i++){
            if(i<MaxDefendersNumber){
                slots[i].gameObject.SetActive(true);
                prices[i].gameObject.SetActive(true);
            }
            else{
                slots[i].gameObject.SetActive(false);
                prices[i].gameObject.SetActive(false);
            }
        }
    }
    public void FillAllDefendersSlots(){
        defendersList.FillAvailableSlots(slots, prices, defendersList.AllDefenders);
    }

    public void ClickHandler(int id){
        
        if(slots[id].gameObject.activeSelf){
            defendersList.Choose(id);
        }
        else{
            //defendersList.CancelChoose(id);
        }

        slots[id].gameObject.SetActive(!slots[id].gameObject.activeSelf);
        prices[id].gameObject.SetActive(!prices[id].gameObject.activeSelf);

    }

    public void CancelClickHandler(int id, int pos){
        
        defendersList.CancelChoose(id,pos);
        
        slots[id].gameObject.SetActive(true);
        prices[id].gameObject.SetActive(true);

    }


}
