using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicAndAudioVolumeController : MonoBehaviour
{
    public AudioSource[] musicHolders, soundHolders;

    void Start(){
        updateVolume();
    }

    public void updateVolume(){
        foreach(var musicHolder in musicHolders){
            if(PlayerPrefs.GetInt("music", 1) == 0){
                musicHolder.volume = 0;
            }
            else{
                musicHolder.volume = 1;
            }
        }

        foreach(var soundHolder in soundHolders){
            if(PlayerPrefs.GetInt("sound", 1) == 0){
                soundHolder.volume = 0;
            }
            else{
                soundHolder.volume = 1;
            }
        }
    }
}
