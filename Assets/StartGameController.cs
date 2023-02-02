using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameController : MonoBehaviour
{
    public DefendersListController listController;
    public GameObject ChooseDefendersPanel;

    public EnemySpawner enemySpawner;

    void Start(){
        ChooseDefendersPanel.gameObject.SetActive(true);
    }
    public void StartGame(){
        if(listController.ChoosenDefenders.Count>=3){
            DefendersListController.GameStarted = true;
            ChooseDefendersPanel.gameObject.SetActive(false);
            enemySpawner.StartGame();
        }
    }
}
