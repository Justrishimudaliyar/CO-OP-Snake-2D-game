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
            //StartCoroutine(TimeDelay());
            Loader.LoaderCallback();
        }
    }

    //IEnumerator TimeDelay()
    //{
    //    yield return new WaitForSeconds(2.0f);
    //    Loader.LoaderCallback();
    //}
}
