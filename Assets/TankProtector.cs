using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankProtector : CactusProtector
{
    void Start(){

        this.Init();
        numberOfAims=0;
        
        bullet.speed = 0;
        if(delay<=1){
            delay=1.5f;
        }
        if(bulletSpeed<3){
            bulletSpeed=3;
        }
        StartCoroutine(Shoot());
    }
}
