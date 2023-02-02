using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public GameObject musicOn, musicOff;

    public GameObject soundOn, soundOff;

    public GameObject undoProgressPanel;

    public AudioSource undoProgressAudioEffect;

    public MusicAndAudioVolumeController volume;

    void Start(){
        updateMusicUi();
        updateSoundUi();
    }
    
    public void muteUnmuteMusic(){
        if (PlayerPrefs.GetInt("music", 1) == 0){
            PlayerPrefs.SetInt("music", 1);
        }
        else {
            PlayerPrefs.SetInt("music", 0);
        }

        updateMusicUi();
        volume.updateVolume();
    }

    public void muteUnmuteSound(){
        if (PlayerPrefs.GetInt("sound", 1) == 0){
            PlayerPrefs.SetInt("sound", 1);
        }
        else {
            PlayerPrefs.SetInt("sound", 0);
        }

        updateSoundUi();
        volume.updateVolume();
    }

    void updateMusicUi(){
        musicOff.gameObject.SetActive(PlayerPrefs.GetInt("music", 1) == 0);
        musicOn.gameObject.SetActive(PlayerPrefs.GetInt("music", 1) != 0);
    }

    void updateSoundUi(){
        soundOff.gameObject.SetActive(PlayerPrefs.GetInt("sound", 1) == 0);
        soundOn.gameObject.SetActive(PlayerPrefs.GetInt("sound", 1) != 0);
    }

    public void setUndoProgressPanelActive(bool active){
        undoProgressPanel.SetActive(active);
    }

    public void undoProgress(){
        PlayerPrefs.DeleteAll();

        this.undoProgressAudioEffect.Play();

        setUndoProgressPanelActive(false);
    }

    public void rate(){
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.VertexStudioGames.FarmersTower");
    }
}
