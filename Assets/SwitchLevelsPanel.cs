using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchLevelsPanel : MonoBehaviour
{
    public GameObject[] levelsPanels;

    private int current;

    void Start(){
        current=0;

        HideAll();
        levelsPanels[current].SetActive(true);
    }

    public void Next(){
        current++;

        if(current>levelsPanels.Length-1){
            current=0;
        }

        HideAll();

        levelsPanels[current].SetActive(true);
    }

    public void Prev(){
        current--;

        if(current<0){
            current=levelsPanels.Length-1;
        }

        HideAll();

        levelsPanels[current].SetActive(true);
    }

    private void HideAll(){
        foreach(var panel in levelsPanels){
            panel.SetActive(false);
        }
    }
}
