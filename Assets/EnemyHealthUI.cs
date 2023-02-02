using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealthUI : MonoBehaviour
{
    public TextMeshPro health;
    
    public void Init(){
        health.transform.eulerAngles = new Vector3(health.transform.eulerAngles.x, health.transform.eulerAngles.y - transform.eulerAngles.y, health.transform.eulerAngles.z);
    }

    public void ShowHealthValue(int value){
        if(value == 0){
            Destroy(health.gameObject);
            return;
        }
        health.text = value.ToString();
    }
}
