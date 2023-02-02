using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropController : MonoBehaviour
{
    private float yTarget = 2;
    public WaterController water;

    private ParticleSystem pickEffect;

    void Start(){
        pickEffect = gameObject.transform.GetChild(0).transform.gameObject.GetComponent<ParticleSystem>();

        Invoke(nameof(PickWater), 6);
    }



    void Update(){
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, yTarget, transform.position.z), 0.25f);
    }

    void OnMouseDown(){
        PickWater();
        CancelInvoke(nameof(PickWater));
    }

    void PickWater(){
        pickEffect.gameObject.transform.parent = null;
        pickEffect.Play();
        water.Pick();
        Destroy(gameObject);
    }

}
