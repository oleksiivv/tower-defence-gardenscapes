using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudyController : MonoBehaviour
{
    public GameObject[] studyPanels;

    public ScenesLoadingController scenesLoadingController;

    public WaterController water;

    int current = -1;

    int last;

    void Start(){
        last=studyPanels.Length-1;
        
		Next();
    }
    
    public void NextButtonHandler(){
    	CancelInvoke(nameof(Next));
    	Next();
    }

    public void Next(){
        if(DefendersListController.GameStarted){
            if (current == 0)
            {
                water.PickAmount(120);
            }

            current++;

            if(last == current%studyPanels.Length && last<current){
                current++;
            }
            
            if(current>studyPanels.Length*3-1){
                hideAll();
            }
            else{
                show(current);
            }
        }
        
    	Invoke(nameof(Next), 6f);
    }

    void show(int n){
        hideAll();

        studyPanels[n%studyPanels.Length].SetActive(true);
    }

    void hideAll(){
        foreach(var panel in studyPanels){
            panel.SetActive(false);
        }
    }


    public void completeStudy(int scene){
    DefendersListController.GameStarted = false;
    hideAll();
        PlayerPrefs.SetInt("studied", 1);
        scenesLoadingController.openScene(scene);
    }
}
