using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombProtector : Protector
{
    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag.ToLower().Equals("enemy")){
            Destroy(other.gameObject);
            DeathBehavior();
        }
    }

    void OnCollisionStay(Collision other){
        if(other.gameObject.tag.ToLower().Equals("enemy")){
            Destroy(other.gameObject);
            DeathBehavior();
        }
    }

}
