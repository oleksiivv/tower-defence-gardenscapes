using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellController : MonoBehaviour
{
    public PlaceObjectsController placeObjectsController;


    void OnMouseDown(){
        if(!HomeController.alive)return;
        if(placeObjectsController.cleanerChoosen){
            placeObjectsController.CleanCell(gameObject);
        }
        else{
            var newObj = placeObjectsController.Place(gameObject);
            newObj.transform.position = new Vector3(newObj.transform.position.x, 0.6f, newObj.transform.position.z);

            if(this.gameObject.name.ToLower().Contains("vertical")){
                newObj.transform.eulerAngles = new Vector3(0, 90,0);
            }
            else{
                newObj.transform.eulerAngles = new Vector3(0, 180, 0);
            }

            newObj.gameObject.transform.parent = this.gameObject.transform;
            newObj.AddComponent<DefenderController>().placeObjectsController = this.placeObjectsController;
        }
    }
}
