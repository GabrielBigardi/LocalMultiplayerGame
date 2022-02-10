using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateOrtographicSize : MonoBehaviour
{
    public int verticalResolution;
    public int pixelsPerUnit;
    public int scale;

    void Update()
    {
        var result = (((float)verticalResolution) / ((float)scale * pixelsPerUnit)) * 0.5f;
        Debug.Log(result);
    }
}
