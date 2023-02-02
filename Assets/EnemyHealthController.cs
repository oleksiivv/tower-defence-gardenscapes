using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public EnemyHealthUI healthUi;
    public int healthValue=100;

    void Start(){
        if(healthValue<80){
            healthValue=100;
        }

        healthUi=gameObject.GetComponent<EnemyHealthUI>();
        healthUi.Init();
        healthUi.ShowHealthValue(healthValue);
    }

    public void ReceiveDamage(int n){
        healthValue-=n;
        if(healthValue<0){
            healthValue=0;
        }
        healthUi.ShowHealthValue(healthValue);
        
    }

    public bool alive(){
        return healthValue>0;
    }
}
