using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class PlaceObjectsController : MonoBehaviour
{
    public GameObject[] defenders, cells;
    public Image[] chooseDefenderItem;
    public ColorsController colorsController;
    private int current = -1;
    private List<MeshRenderer> cellMeshes;
    public Animator cleaner;
    public bool cleanerChoosen=false;

    public WaterController water;

    public DefendersListController defendersList;

    //public DefendersListController listController;

    void Start(){
        cellMeshes = new List<MeshRenderer>();
        for(int i=0; i<cells.Length; i++){
            cellMeshes.Add(cells[i].GetComponent<MeshRenderer>());
        }
        ResetItems();
    }

    private void setCellsVisibility(bool visibility){
        foreach(var mesh in cellMeshes){
            //Debug.Log(mesh.gameObject.name);
            mesh.enabled=visibility;
        }
        if(!visibility){
            current=-1;
        }
    }

    private void ResetItems(){
        setCellsVisibility(false);
        current = -1;
        foreach(var item in chooseDefenderItem){
            item.GetComponent<Image>().color = colorsController.normalItemColor;
        }
    }
    public void Choose(int item){
        
        if(!HomeController.alive)return;
        
        if(!DefendersListController.GameStarted){
            defendersList.Choose(item);
            return;
        }
        //Debug.Log("Item №"+item.ToString());
        int n = Convert.ToInt32(EventSystem.current.currentSelectedGameObject.name.Split(':')[1]);
        if(current == item){
            current = -1;
            setCellsVisibility(false);
            chooseDefenderItem[n].GetComponent<Image>().color = colorsController.normalItemColor;
            return;
        }
        if(water.waterAmount >= defendersList.ChoosenDefenders[n].Price){
            ResetItems();
            current=item;
            chooseDefenderItem[n].GetComponent<Image>().color = colorsController.choosenItemToPlace;
            setCellsVisibility(!cellMeshes[0].enabled);
        }
    }

    public GameObject Place(GameObject cell){

        GameObject newDefender = null;
        if(current != -1){
            newDefender = Instantiate(defenders[current], new Vector3(cell.transform.position.x, transform.position.y, cell.transform.position.z), defenders[current].transform.rotation) as GameObject;
            water.waterAmount -= defendersList.AllDefenders[current].Price;
            water.ShowWaterAmount();
        }
        ResetItems();
        setCellsVisibility(false);

        return newDefender;
    }

    public void ChooseCleaner(){
        cleanerChoosen = !cleanerChoosen;
        cleaner.enabled = cleanerChoosen;
        setCellsVisibility(cleanerChoosen);

        if(!cleanerChoosen){
            cleaner.gameObject.GetComponent<Image>().color = colorsController.cleanerNormal;
        }
    }
    public void CleanCell(GameObject cell){
        for(int i=0; i< cell.transform.childCount; i++){
            Destroy(cell.transform.GetChild(i).gameObject);
        }
        ChooseCleaner();
    }
}
