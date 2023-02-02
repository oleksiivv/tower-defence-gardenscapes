using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource audioSource;

    public AudioClip[] clips;

    void Start(){

        if(PlayerPrefs.GetInt("music", 1) == 0){
            audioSource.volume = 0;            
        }
        else{
            audioSource.volume = 1;
        }

        if(audioSource==null){
            audioSource=gameObject.GetComponent<AudioSource>();
        }

        audioSource.enabled=false;

        audioSource.clip = clips[Random.Range(0, clips.Length)];
        
        audioSource.enabled=true;

        audioSource.Play();
    }
}
