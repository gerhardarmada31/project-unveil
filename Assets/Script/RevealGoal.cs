using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RevealGoal : MonoBehaviour
{
    [SerializeField] private int requiredAmount;
    private GameObject revealSphere;
    [SerializeField] private float xScaleReveal = 20f;
    [SerializeField] private float zScaleReveal =20f;

    private void Awake()
    {
        revealSphere = this.gameObject.transform.GetChild(0).gameObject;
        revealSphere.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var currentAmount = other.GetComponent<PlayerStatus>().CurrentSpiritAmount;
            if (currentAmount >= requiredAmount)
            {
                revealSphere.SetActive(true);
                StartCoroutine(ScaleOverSeconds(revealSphere, new Vector3(xScaleReveal, 10f, zScaleReveal), 5f));
                Debug.Log("BIGREVEAL");
            }
            else
            {
                Debug.Log("not enough spirits");
            }
        }
    }



    public IEnumerator ScaleOverSeconds(GameObject objectToScale, Vector3 scaleTo, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingScale = objectToScale.transform.localScale;
        while (elapsedTime < seconds)
        {
            objectToScale.transform.localScale = Vector3.Lerp(startingScale, scaleTo, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
    }
}
