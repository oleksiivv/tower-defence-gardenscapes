using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TemorarlyProtector : Protector
{
    protected int health=200;

    protected void Start(){

    }
    
    void OnCollisionStay(Collision other){
        if(other.gameObject.tag.ToLower().Equals("enemy")){
            health--;
            if(health<=5){
                DeathBehavior();
            }
        }
    }

    protected void OnTriggerEnter(Collider other){
        if(other.gameObject.name.Contains("AllCleanerBomb")){
            DeathBehavior();
        }
    }
}
