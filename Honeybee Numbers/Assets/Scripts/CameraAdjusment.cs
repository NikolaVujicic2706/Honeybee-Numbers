using System.Collections;
using System.Collections.Generic;
using UnityEngine;





[RequireComponent(typeof(Camera))]

public class CameraAdjusment : MonoBehaviour
{
    public float sceneWidth = 21.5f;

    Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
       
        
    }

    void Update()
    {
        float unitsPerPixel = sceneWidth / Screen.width;

        if (unitsPerPixel >= 1)
        {
            _camera.orthographicSize = Screen.height/2;
        }
        else
        {
            float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;
           

            _camera.orthographicSize = desiredHalfHeight;
        }

        
    }
}
