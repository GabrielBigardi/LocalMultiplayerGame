using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zoom : MonoBehaviour
{
    private Camera ppwzCamera;
    private PerfectPixelCameraWithZoom ppwz;

    void Start()
    {
        ppwzCamera = GetComponent<Camera>();
        ppwz = ppwzCamera.GetComponent<PerfectPixelCameraWithZoom>();
    }

    void Update()
    {
        if (Input.mouseScrollDelta.y != 0)
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                ppwz.ZoomIn();
            }
            else
            {
                ppwz.ZoomOut();
            }
        }
    }
}