using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;

    [HideInInspector]
    public EnemiesCounter enemiesCounter;

    [HideInInspector]
    public EnemyHealthController healthController;

    public ParticleSystem DieEffect;


    public ItemsSpawnController itemsSpawnController;

    [HideInInspector]
    public bool xDir=false;
    private float xAxis;
    private float zAxis;

    void Start(){
        if(speed == 0){
            speed = 1;
        }

        if(healthController==null){
            healthController = gameObject.GetComponent<EnemyHealthController>();
        }
        if(itemsSpawnController==null){
            itemsSpawnController = gameObject.GetComponent<ItemsSpawnController>();
        }

        xAxis = gameObject.transform.position.x;
        zAxis = gameObject.transform.position.z;
    }

    void Update(){
        if(Mathf.Abs(transform.position.y)>2){
            OnDamageGet(healthController.healthValue);
        }

        if(xDir) transform.position = new Vector3(xAxis, transform.position.y, transform.position.z);
        else transform.position = new Vector3(transform.position.x, transform.position.y, zAxis);

        transform.Translate(Vector3.forward/160*speed*Time.timeScale);
    }

    public bool OnDamageGet(int damage=10){
        Debug.Log("Damaged GameObject@"+gameObject.name);
        
        healthController.ReceiveDamage(damage);

        if(!healthController.alive()){
            DieEffect.gameObject.transform.parent=null;
            DieEffect.Play();

            speed=0;

            TryInstantiateCoin();

            Invoke(nameof(CleanUp), 0.25f);

            return true;
        }

        return false;
    }

    void TryInstantiateCoin(){    
        if(Random.Range(0, 5) == 1){
            itemsSpawnController.CreateCoin();
        }
    }

    void CleanUp(){
        Destroy(gameObject);
    }

    void OnDestroy(){
        enemiesCounter.DestroyedEnemiesCount  += 1;
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.ToLower().Equals("enemy-cleaner")){
            OnDamageGet(healthController.healthValue);
        }
    }
}
