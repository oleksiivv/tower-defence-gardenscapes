using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuSurvivalLevelPanelController : MonoBehaviour
{
    public GameObject survivalPanel;

    public Text hi;

    void Start(){
        hi.text = PlayerPrefs.GetInt("hi", 0).ToString();
    }

    public void setSurvivalPanelVisibility(bool visibility){
        survivalPanel.gameObject.SetActive(visibility);
    }
}
