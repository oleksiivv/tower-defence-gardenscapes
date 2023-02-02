using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderController : MonoBehaviour
{
    public PlaceObjectsController placeObjectsController;


    void OnMouseDown(){
        if(placeObjectsController.cleanerChoosen){
            Destroy(gameObject);
            placeObjectsController.ChooseCleaner();
        }
    }
}
