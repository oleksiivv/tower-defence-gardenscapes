using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CactusProtector : TemorarlyProtector
{
    
    public Bullet bullet;
    public float delay;

    public float bulletSpeed = 3;

    [HideInInspector]
    public int numberOfAims;

    private GameObject currentAim;
    
    void Start(){

        currentAim = null;

        this.Init();
        numberOfAims=0;

        bullet.speed = 0;
        if(delay<=0.4f){
            delay=0.5f;
        }
        if(bulletSpeed<3){
            bulletSpeed=3;
        }
        StartCoroutine(Shoot());
    }

    protected IEnumerator Shoot(Vector3 bulletPos = default(Vector3)){
        if(bulletPos==null || bulletPos == Vector3.zero){
            bulletPos = transform.position+new Vector3(0,0.25f,0);
        }
        while(true){
            yield return new WaitForSeconds(delay);
            if(DefendersListController.GameStarted && numberOfAims>0){
                var newBullet = Instantiate(bullet.gameObject, bulletPos, bullet.transform.rotation) as GameObject;

                newBullet.transform.parent = this.transform;

                //newBullet.transform.Rotate(45,0,0);

                newBullet.GetComponent<Bullet>().direction = transform.forward;
                newBullet.GetComponent<Bullet>().speed = bulletSpeed;
                newBullet.GetComponent<Bullet>().protector = this;

                if(transform.eulerAngles.y>170 && transform.eulerAngles.y<190){
                    newBullet.GetComponent<Bullet>().flyEffectStartRotationY = -90;
                }
            }
        }
    }


    void Update(){
        if(currentAim == null && numberOfAims > 0){
            numberOfAims--;
        }
    }


    public void OnTriggerEnter(Collider other){
        base.OnTriggerEnter(other);
        if(other.gameObject.tag.ToLower().Equals("enemy")){
            currentAim = other.gameObject;
            numberOfAims++;
            Debug.Log(gameObject.name+"++: "+numberOfAims.ToString());
        }
    }

    public void OnTriggerExit(Collider other){
        if(other.gameObject.tag.ToLower().Equals("enemy")){
            currentAim = null;
            numberOfAims--;
            Debug.Log(gameObject.name+"--: "+numberOfAims.ToString());
        }
    }

}
