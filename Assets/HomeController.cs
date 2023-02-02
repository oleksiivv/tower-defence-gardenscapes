using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class HomeController : MonoBehaviour
{

    public ParticleSystem boomEffect;

    public static bool alive = true;

    public UIController ui;

    public AdmobController admob;

    public static int adsShowCounter = 1;

    void Start(){
        alive = true;
        adsWasShown=false;
    }

    bool adsWasShown=false;
    
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag.ToLower().Contains("enemy") && !other.gameObject.tag.ToLower().Contains("cleaner")){
            HomeController.alive = false;
            boomEffect.Play();
            ui.SetDeathPanelActive(true);

            //if(adsShowCounter%2==0){
            if(!adsWasShown){
                admob.showIntersitionalAd();
                adsWasShown=true;
            }
            //}

            //adsShowCounter++;
        }
    }
}
