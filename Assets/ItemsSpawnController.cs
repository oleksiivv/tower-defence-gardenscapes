using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsSpawnController : MonoBehaviour
{
    public CoinsController coinsController;
    public GameObject coin;

    public void CreateCoin(){
        var newCoin = Instantiate(coin, new Vector3(transform.position.x, 0.5f, transform.position.z), transform.rotation) as GameObject;

        newCoin.GetComponent<CoinController>().coins = this.coinsController;
    }
}
