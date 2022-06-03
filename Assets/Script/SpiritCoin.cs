using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiritCoin : MonoBehaviour
{
    [SerializeField] private int coinAmount = 1;


    private void OnTriggerEnter(Collider other)
    {
        //Destroy coin
        //Make an inteface that adds to the playerStatus coin
        ICollectable _dropCollect = other.GetComponent<ICollectable>();
        _dropCollect.CollectCoin(coinAmount);
        Object.Destroy(this.gameObject);
    }
}
