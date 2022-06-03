using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus : MonoBehaviour, ICollectable
{
    //[SerializeField] int currentSpiritAmount;
    private int currentSpiritAmount;
    public int CurrentSpiritAmount
    {
        get { return currentSpiritAmount; }
        set { currentSpiritAmount = value; }
    }

    [SerializeField] GameObject revealSphere;
    private Vector3 revealSphereSize = new Vector3(3f, 3f, 3f);
    //Vector Reveal add;



    private void Awake()
    {
        revealSphere = this.gameObject.transform.GetChild(1).gameObject;
        //get the revealSphere scale
    }

    //When coin is collected
    public void CollectCoin(int coin)
    {
        currentSpiritAmount += coin;
        revealSphereSize += new Vector3(coin, 0, coin);
        // var scaler = revealSphere.transform.localScale += new Vector3(0.5f, 0.5f, 0.5f);
        //revealSphere.transform.localScale = Vector3.Lerp(revealSphere.transform.localScale, revealSphere.transform.localScale + new Vector3(0.5f, 0.5f, 0.5f), 1f);

        StartCoroutine(ScaleOverSeconds(revealSphere, revealSphereSize, 0.5f));
        //Make the revealSphere bigger
    }


    public IEnumerator ScaleOverSeconds(GameObject objectToScale, Vector3 scaleTo, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingScale = objectToScale.transform.localScale;
        while (elapsedTime < seconds)
        {
            //
            objectToScale.transform.localScale = Vector3.Lerp(startingScale, scaleTo, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        // objectToScale.transform.position = scaleTo;
    }


}
