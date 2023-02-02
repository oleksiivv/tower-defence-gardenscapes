using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemies;
    public Vector3[] spawnPoints;

    public float startDelay;

    public float delay;

    public GameObject target;

    public EnemiesCounter enemiesCounter;

    public int MaxEnemiesNumber;

    public CoinsController coinsController;

    public bool infinity=false;

    public void StartGame(){
        enemiesCounter.enemiesLabel.SetActive(false);
        Invoke(nameof(StartEnemySpawn), startDelay);
    }

    void StartEnemySpawn(){
        enemiesCounter.enemiesLabel.SetActive(true);
        StartCoroutine(EnemySpawn());
    }


    IEnumerator EnemySpawn(){
        while(true){
            if((enemiesCounter.CanInstantiateNew() || infinity) && DefendersListController.GameStarted){
                //int enemy = Random.Range(0,enemies.Length);

                int enemy = Random.Range(0, MaxEnemiesNumber);

                //Debug.Log("Old: "+enemies[enemy].transform.eulerAngles);
                var newEnemy = Instantiate(enemies[enemy], spawnPoints[Random.Range(0, spawnPoints.Length)], enemies[enemy].transform.rotation) as GameObject;
                RotateObjectToTarget(newEnemy, target);

                //Debug.Log("New: "+newEnemy.transform.eulerAngles);
                if(!infinity)enemiesCounter.EnemiesCount += 1;

                newEnemy.GetComponent<EnemyController>().enemiesCounter = this.enemiesCounter;
                newEnemy.GetComponent<EnemyController>().itemsSpawnController.coinsController = this.coinsController;
            }

            yield return new WaitForSeconds(delay);
            
            if(delay > 0.5f)delay *= 0.92f;
        }
    }

    void RotateObjectToTarget(GameObject obj, GameObject target){
        Vector3 diff = target.transform.position - obj.transform.position;
            
        var newDir = Vector3.RotateTowards(transform.forward, diff, 1, 0.0F);
        
        obj.transform.rotation = Quaternion.LookRotation(newDir);
        obj.transform.eulerAngles = new Vector3(0, obj.transform.eulerAngles.y % 350 < 10 ? 0 : 270, 0);
        
        obj.GetComponent<EnemyController>().xDir = obj.transform.eulerAngles.y < 10;
    }
}
