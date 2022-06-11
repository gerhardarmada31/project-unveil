using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigReveal : MonoBehaviour
{
    private GameObject revealSphere;
    private float xScaleReveal = 20f;
    private float zScaleReveal = 20;

    // Start is called before the first frame update
    void Start()
    {
        ScaleOverCall();
    }

    public void ScaleOverCall()
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        StartCoroutine(ScaleOverSeconds(this.gameObject, new Vector3(xScaleReveal, 10f, zScaleReveal), 5f));
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
