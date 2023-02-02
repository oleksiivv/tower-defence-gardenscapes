using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WellProtector : TemorarlyProtector
{
    public WaterDropController waterDrop;
    public WaterController water;

    void Start(){
        this.Init();
        water = GameObject.Find("PlaceObjectsController").GetComponent<WaterController>();
        StartCoroutine(spawn());
    }

    IEnumerator spawn(){
        while(true){
            yield return new WaitForSeconds(Random.Range(3f, 5f));
            if(DefendersListController.GameStarted){
                var drop = Instantiate(waterDrop.gameObject, transform.position+new Vector3(Random.Range(-1f, 1f), 1, Random.Range(-1f, 1f)) ,waterDrop.transform.rotation) as GameObject;

                drop.GetComponent<WaterDropController>().water = this.water;
            }
        }
    }

    
}
