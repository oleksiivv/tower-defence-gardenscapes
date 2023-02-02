using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    //private float yTarget = 2;
    public CoinsController coins;

    private ParticleSystem pickEffect;

    void Start(){
        pickEffect = gameObject.transform.GetChild(0).transform.gameObject.GetComponent<ParticleSystem>();

        Invoke(nameof(PickCoin), 6);
    }



    void Update(){
        //transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, yTarget, transform.position.z), 0.25f);
    }

    void OnMouseDown(){
        PickCoin();
        CancelInvoke(nameof(PickCoin));
    }

    void PickCoin(){
        pickEffect.gameObject.transform.parent = null;
        pickEffect.Play();
        coins.Pick();
        Destroy(gameObject);
    }
}
