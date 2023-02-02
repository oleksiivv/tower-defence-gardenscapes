using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemiesCounter : MonoBehaviour
{
    public WInController winController;
    public GameObject enemiesLabel;
    public Text enemiesCounterLabel;
    private int enemiesCount;
    public int maxEnemiesCount;

    public bool infinityLevel = false;

    public InfinityLevelController infinityLevelController = null;

    public Text hiInfinityLevel = null;

    void Start(){
        this.enemiesCounterLabel.text="";
        if(hiInfinityLevel!=null){
            hiInfinityLevel.text = PlayerPrefs.GetInt("hi").ToString();
        }
    }

    public int EnemiesCount {
        get{
            return this.enemiesCount;
        }
        set{
            if(!infinityLevel){
                this.enemiesCount = value;
                //this.enemiesCounterLabel.text = this.enemiesCount.ToString() + "/" + this.maxEnemiesCount.ToString();
            }
        }
    }

    private int destroyedEnemiesCount;

    public int DestroyedEnemiesCount {
        get {
            return this.destroyedEnemiesCount;
        }
        set {
            this.destroyedEnemiesCount = value;
            this.enemiesCounterLabel.text = this.destroyedEnemiesCount.ToString() + "/" + this.maxEnemiesCount.ToString();
            if(this.destroyedEnemiesCount == maxEnemiesCount && !infinityLevel){
                WinBeahviour();
            }
            if(infinityLevelController != null){
                infinityLevelController.enemiesCounterText.text = this.destroyedEnemiesCount.ToString();
                if(hiInfinityLevel != null && this.destroyedEnemiesCount > PlayerPrefs.GetInt("hi")){
                    PlayerPrefs.SetInt("hi", this.destroyedEnemiesCount);
                    hiInfinityLevel.text = PlayerPrefs.GetInt("hi").ToString();
                }
            }
        }
    }

    public void WinBeahviour(){
        this.winController.winPanel.gameObject.SetActive(true);
        this.winController.WinBehavior();
    }

    public bool CanInstantiateNew(){
        return this.enemiesCount < this.maxEnemiesCount;
    }

}
