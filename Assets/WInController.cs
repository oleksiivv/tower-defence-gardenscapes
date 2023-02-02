using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WInController : MonoBehaviour
{
    public GameObject winPanel;
    public bool hasNewItem;

    [Min(1)]
    public int levelNumber = 1;

    public Sprite newItemSprite;

    public string newItemName;

    public GameObject newItemPanel;

    public Image newItemImage;

    public Text newItemText;


    void ShowNewItem(){
        newItemPanel.gameObject.SetActive(true);
        newItemImage.sprite = newItemSprite;
        newItemText.text = newItemName;
    }

    public void WinBehavior(){
        newItemPanel.gameObject.SetActive(false);

        PlayerPrefs.SetInt("level@"+Application.loadedLevel.ToString(), 1);

        if(hasNewItem){
            PlayerPrefs.SetInt("NumberOfNewItems", PlayerPrefs.GetInt("NumberOfNewItems")+1);
            //PlayerPrefs.SetInt("NumberOfNewItems", levelNumber);
            newItemPanel.gameObject.SetActive(true);
            ShowNewItem();
        }
    }
}
