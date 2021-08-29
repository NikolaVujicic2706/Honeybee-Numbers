using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTest : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        float screenRatio = (float)Screen.width / (float)Screen.height;
        float targetRatio = 2.1666f;

        if (screenRatio >= targetRatio)
        {
            Camera.main.orthographicSize = 21.5f / 2;
        }
        else
        {
            float differenceInSize = targetRatio / screenRatio;
            Camera.main.orthographicSize = 10 / 2 * differenceInSize;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
