using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusWaterRocket : MonoBehaviour
{
    public Vector3 boomPosition;
    private ParticleSystem effect;

    public WaterController water;

    void Start(){
        effect=gameObject.transform.GetChild(0).transform.GetComponent<ParticleSystem>();
    }
    
    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, boomPosition, 0.1f);

        if(transform.position == boomPosition){
            water.PickAmount(200);
            effect.gameObject.transform.parent=null;
            effect.Play();
            Destroy(gameObject);
        }
    }
}
