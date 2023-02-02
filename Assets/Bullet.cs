using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    
    public Vector3 direction;
    public float speed;

    public ParticleSystem deathEffectPrephab;

    protected ParticleSystem deathEffect;

    [HideInInspector]
    public CactusProtector protector;


    public float flyEffectStartRotationY;

    public GameObject flyEffect;

    void Start(){

        transform.position += direction/2;
        flyEffect.transform.eulerAngles = new Vector3(transform.eulerAngles.x, flyEffectStartRotationY, transform.eulerAngles.z);
        var deathEffectObject = Instantiate(deathEffectPrephab.gameObject, transform.position, deathEffectPrephab.transform.rotation) as GameObject;
        deathEffect = deathEffectObject.GetComponent<ParticleSystem>();
        deathEffect.gameObject.transform.parent = this.gameObject.transform;

        if(direction==null){
            direction=Vector3.forward;
        }

        Invoke(nameof(CleanUp), 15);
    }

    void Update(){
        transform.Translate(direction/70f*speed);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag.ToLower().Equals("enemy")){
            
            deathEffect.Play();
            deathEffect.gameObject.transform.parent = null;

            CleanUp();

            bool destroyed = other.gameObject.GetComponent<EnemyController>().OnDamageGet(25);

            Debug.Log(protector.numberOfAims+": number of aims!!!");

            if(destroyed || other==null){
                protector.numberOfAims--;
            }
        }
    }

    public void CleanUp(){
        Destroy(gameObject);
    }

}
