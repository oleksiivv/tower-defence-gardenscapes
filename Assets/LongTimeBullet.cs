using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongTimeBullet : Bullet
{
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.ToLower().Equals("enemy")){
            
            deathEffect.Play();
            deathEffect.gameObject.transform.parent = null;

            CleanUp();

            bool destroyed = other.gameObject.GetComponent<EnemyController>().OnDamageGet(50);

            Debug.Log(protector.numberOfAims+": number of aims!!!");

            if(destroyed || other==null){
                protector.numberOfAims--;
            }
        }
    }
}
