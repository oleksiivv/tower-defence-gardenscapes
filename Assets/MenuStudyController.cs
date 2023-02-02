using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuStudyController : MonoBehaviour
{
    public GameObject studyPanel;

    public ScenesLoadingController scenesLoadingController;


    public void Init(){
        studyPanel.SetActive(false);

        if(PlayerPrefs.GetInt("studied", 0) == 0){
            studyPanel.SetActive(true);

            var shopItems = new List<ShopItem>();

            shopItems.Add(new ShopItem { name = "Bomb", price = 150 });
            shopItems.Add(new ShopItem { name = "Hydrant", price = 250 });
            shopItems.Add(new ShopItem { name = "BombPrime", price = 450 });

            foreach(var item in shopItems)
            {
                item.buyForFree();
            }
        }
    }

    public void startStudy(){
        scenesLoadingController.openScene(18);
    }

    public void skipStudy(){
        PlayerPrefs.SetInt("studied", 1);
        studyPanel.SetActive(false);
    }
}
