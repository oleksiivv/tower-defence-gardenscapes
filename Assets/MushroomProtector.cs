using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomProtector : TemorarlyProtector
{
    void Start(){
        this.Init();
        health=2000;
        transform.position -= new Vector3(0, 0.3f, 0);
    }
    
}
