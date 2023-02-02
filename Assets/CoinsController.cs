using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsController : MonoBehaviour
{
    public int coinsAmount;
    public Text coinsAmountLabel;

    public GameObject coinsLabel;

    void Start(){
        hideCoinsLabel();
        coinsAmount = PlayerPrefs.GetInt("coins", 0);
        ShowCoinsAmount();
    }
    public void Pick(){
        coinsAmount += 5;

        PlayerPrefs.SetInt("coins", coinsAmount);

        ShowCoinsAmount();
    }
    public void ShowCoinsAmount(){
        coinsLabel.SetActive(true);

        coinsAmountLabel.text = coinsAmount.ToString();

        Invoke(nameof(hideCoinsLabel), 2);
    }

    void hideCoinsLabel(){
        coinsLabel.SetActive(false);
    }
}
