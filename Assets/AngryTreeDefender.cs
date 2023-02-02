using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngryTreeDefender : CactusProtector
{
    public Vector3 rightBulletPos;
    public Vector3 leftBulletPos;
    void Start(){

        bullet.speed = 0;
        if(delay<=1){
            delay=1.3f;
        }
        if(bulletSpeed<2.5){
            bulletSpeed=2.5f;
        }

        StartCoroutine(Shoot());

        Invoke(nameof(LeftBulletStart), delay/10f);
    }

    void LeftBulletStart(){
        StartCoroutine(Shoot());
    }
}
