using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class ExitGoal : MonoBehaviour
{
    private static Light2D exitLight;
    // Start is called before the first frame update
    void Start()
    {
        exitLight = GetComponent<Light2D>();
        exitLight.intensity = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetExitLightOn()
    {
        exitLight.intensity = 1;
    }
}
