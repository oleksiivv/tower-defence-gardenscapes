using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelController : MonoBehaviour
{
    public GameObject[] elems;
    public float delay=1;

    void Start(){
        foreach(var elem in elems){
            elem.SetActive(false);
        }
        Invoke(nameof(ShowElems), delay);
    }

    void ShowElems(){
        foreach(var elem in elems){
            elem.SetActive(true);
        }
    }
}
