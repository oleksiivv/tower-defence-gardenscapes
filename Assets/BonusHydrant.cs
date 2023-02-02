using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusHydrant : MonoBehaviour
{
    public Vector3 boomPosition;
    private ParticleSystem effect, addWaterEffect;

    public WaterController water;

    bool picked=false;

    void Start(){
        effect=gameObject.transform.GetChild(0).transform.GetComponent<ParticleSystem>();
        addWaterEffect=gameObject.transform.GetChild(1).transform.GetComponent<ParticleSystem>();

        Invoke(nameof(cleanup), 5);
    }

    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, boomPosition, 0.5f);

        if(transform.position == boomPosition && !picked){
            effect.Play();
            //water.PickAmount(500);

            picked=true;
        }
    }

    void cleanup(){
        water.PickAmount(500);
        addWaterEffect.gameObject.transform.parent=null;
        addWaterEffect.Play();
        Destroy(gameObject);
    }
}
