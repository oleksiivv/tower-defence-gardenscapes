using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public MenuLevelsPanelControler levelsPanelController;

    public MenuSurvivalLevelPanelController survivalLevelPanelController;

    public MenuStudyController study;

    public Text coins;

    void Start(){
        if(PlayerPrefs.GetInt("firstTimeInMenu", 0) == 0)
        {
            PlayerPrefs.SetInt("firstTimeInMenu", 1);
            PlayerPrefs.SetInt("coins", 800);
        }
        coins.text = PlayerPrefs.GetInt("coins", 0).ToString();
    }


    public void showLevelsPanel(){
        study.Init();
        levelsPanelController.setLevelsPanelVisibility(true);
    }

    public void hideLevelsPanel(){
        levelsPanelController.setLevelsPanelVisibility(false);
    }

    public void showSurvivalPanel(){
        study.Init();
        survivalLevelPanelController.setSurvivalPanelVisibility(true);
    }

    public void hideSurvivalPanel(){
        survivalLevelPanelController.setSurvivalPanelVisibility(false);
    }
}
