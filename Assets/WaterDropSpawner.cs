using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDropSpawner : MonoBehaviour
{
    public GameObject waterDrop;
    public Vector2 rightTop, leftBottom;
    public float yTop;

    public WaterController waterController;

    public float waterDelayCoef = 1;

    void Start(){
        StartCoroutine(Spawner());
    }


    IEnumerator Spawner(){
        while(true){
            
            yield return new WaitForSeconds(Random.Range(3f, 5f)*waterDelayCoef);
            if(DefendersListController.GameStarted){
                var drop = Instantiate(waterDrop, 
                                    new Vector3(Random.Range(leftBottom.x, rightTop.x), yTop, Random.Range(leftBottom.y, rightTop.y)), 
                                    waterDrop.transform.rotation) as GameObject;

                drop.GetComponent<WaterDropController>().water = this.waterController;
            }

        }
    }
}
