using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealGoal : MonoBehaviour
{
    [SerializeField] private int requiredAmount;
    private GameObject revealSphere;

    [SerializeField] private float xScaleReveal = 20f;
    [SerializeField] private float zScaleReveal = 20f;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var currentAmount = other.GetComponent<PlayerStatus>().CurrentSpiritAmount;
            if (currentAmount >= requiredAmount)
            {
                // revealSphere.SetActive(true);
                // bigReveal.ScaleOverCall();
                other.GetComponent<PlayerStatus>().ActivateBigReveal();
                // other.GetComponent<PlayerStatus>().CurrentBigRevealStatus = true;
                // Debug.Log("BIGREVEAL");
            }
            else
            {
                Debug.Log("not enough spirits");
            }
        }
    }

}
