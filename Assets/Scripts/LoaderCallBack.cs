using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoaderCallBack : MonoBehaviour
{
    private bool firstUpdate = true;
    private void Update()
    {
        if(firstUpdate)
        {
            firstUpdate = false;
            StartCoroutine(TimeDelay());
        }
    }

    IEnumerator TimeDelay()
    {
        yield return new WaitForSeconds(4.0f);
        Loader.LoaderCallback();
    }
}
