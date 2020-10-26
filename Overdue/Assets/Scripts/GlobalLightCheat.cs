using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class GlobalLightCheat : MonoBehaviour
{
    private static Light2D lt;
    // Start is called before the first frame update
    void Start()
    {
        lt = GetComponent<Light2D>();
        lt.intensity = 0;
    }
    
    public static void ToggleGlobalLightOn()
    {
        lt.intensity = 1;
    }
}
