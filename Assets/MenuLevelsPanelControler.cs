using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuLevelsPanelControler : MonoBehaviour
{
    public GameObject levelsPanel;

    public Image[] levelButtons;

    public Image[] levelPadlocks;

    public Color32 availableLevelColor, unavailableLevelColor;

    public int levelScenesStartsFrom = 1, levelDesertScenesStartsFrom=1, levelWinterScenesStartsFrom=1;

    public ScenesLoadingController scenesLoadingController;

    public AdmobController admob;

    
    void Start(){
        showAvailableLevels();
    }

    private void showAvailableLevels(){
        for(int i = 0; i < levelButtons.Length; i++){
            if(i == 0 || PlayerPrefs.GetInt("level@"+i.ToString(), 0) == 1){
                levelButtons[i].GetComponent<Image>().color = availableLevelColor;
                levelPadlocks[i].gameObject.SetActive(false);
            }
            else{
                levelButtons[i].GetComponent<Image>().color = unavailableLevelColor;
                levelPadlocks[i].gameObject.SetActive(true);
            }
        }
    }

    public void setLevelsPanelVisibility(bool visibility){
        levelsPanel.gameObject.SetActive(visibility);
    }

    public void openLevel(int id){
        if(PlayerPrefs.GetInt("level@"+id.ToString(), 0) == 1 || id == 0){
            scenesLoadingController.openScene(id+levelScenesStartsFrom);
        }
        //admob.showIntersitionalAd();
    }

    public void openLevelDesert(int id){
        if(PlayerPrefs.GetInt("level@"+id.ToString(), 0) == 1 || id == 0){
            scenesLoadingController.openScene(id+levelDesertScenesStartsFrom);
        }
        //admob.showIntersitionalAd();
    }

    public void openLevelWinter(int id){
        if(PlayerPrefs.GetInt("level@"+id.ToString(), 0) == 1 || id == 0){
            scenesLoadingController.openScene(id+levelWinterScenesStartsFrom);
        }
        //admob.showIntersitionalAd();
    }
}
