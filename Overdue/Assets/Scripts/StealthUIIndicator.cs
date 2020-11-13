using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StealthUIIndicator : MonoBehaviour
{
    public enum EyeState
    {
        Closed,
        Ajar,
        Open
    }
    private static Image UIEye;
    public static EyeState CurrentEyeState { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        UIEye = GetComponent<Image>();
    }

    public static void SetUIEyeState(EyeState state)
    {
        if (state != CurrentEyeState)
        {
            CurrentEyeState = state;
        }
    }
    
}
