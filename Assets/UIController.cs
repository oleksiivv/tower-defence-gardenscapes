using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : ScenesLoadingController
{
    
    public GameObject pausePanel;

    public GameObject deathPanel;

    public GameObject winPanel;

    public AdmobController admob;

    void Start(){
        Time.timeScale = 1;
        base.Start();
    }
    

    public void SetDeathPanelActive(bool active){
        deathPanel.SetActive(active);
    }

    public void SetWinPanelActive(bool active){
        winPanel.SetActive(active);
    }

    public void Pause(){
        Time.timeScale = 0;
        pausePanel.SetActive(true);
    }

    public void Resume(){
        Time.timeScale = 1;
        pausePanel.SetActive(false);
    }

    public void Restart(){
        this.openScene(Application.loadedLevel);
    }

    public void MainMenu(){
        this.openScene(0);
    }

    public void NextLevel(){
        /*if(HomeController.adsShowCounter%2==0){
            admob.showIntersitionalAd();
        }*/

        //admob.showIntersitionalAd();
        //HomeController.adsShowCounter++;

        if(Application.levelCount < Application.loadedLevel){
            this.openScene(0);
            return;
        }
        this.openScene(Application.loadedLevel+1);
    }
}
