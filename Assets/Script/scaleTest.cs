using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleTest : MonoBehaviour
{

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
    // ...

    private void Start()
    {
        // var scaleTo = new Vector3(1.5f, 1.5f, 1.5f);
        StartCoroutine(ScaleOverSeconds(this.gameObject, new Vector3(2f,2f,2f), 1.0f));

        //Might have to start and Cancel enums
    }
}
