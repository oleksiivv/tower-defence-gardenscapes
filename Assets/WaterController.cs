using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public int waterAmount;
    public Text waterAmountLabel;

    void Start(){
        if(waterAmount<10)waterAmount = 40;
        ShowWaterAmount();
    }
    public void Pick(){
        waterAmount += 20;
        ShowWaterAmount();
    }

    public void PickAmount(int amount){
        waterAmount += amount;
        ShowWaterAmount();
    }
    public void ShowWaterAmount(){
        waterAmountLabel.text = waterAmount.ToString();
    }
}
