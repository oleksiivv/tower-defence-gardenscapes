using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protector : MonoBehaviour
{
    
    public ParticleSystem boomEffectPrephab;

    [SerializeField]
    protected ParticleSystem boomEffect;

    void Start(){
        Init();
    }

    protected void Init(){
        var boomEffectObject = Instantiate(boomEffectPrephab.gameObject, transform.position, boomEffectPrephab.transform.rotation) as GameObject;
        boomEffect = boomEffectObject.GetComponent<ParticleSystem>();
        boomEffect.gameObject.transform.parent = this.gameObject.transform;
    }
       
    protected void DeathBehavior(){
        Debug.Log("-----------------death---------------");
        boomEffect.gameObject.transform.parent = null;
        boomEffect.Play();
        
        Destroy(gameObject);
    }
}
