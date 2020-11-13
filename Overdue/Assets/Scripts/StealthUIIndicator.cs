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

    private const string Closed = "Closed";
    private const string Ajar = "Ajar";
    private const string Open = "Open";

    private static Image[] UIEyes;
    public static EyeState CurrentEyeState { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        UIEyes = GetComponentsInChildren<Image>();

    }

    public static void SetUIEyeState(EyeState state)
    {
        switch(state)
        {
            case EyeState.Closed:
                foreach (Image eye in UIEyes)
                {
                    if (eye.name.CompareTo(Closed) == 0)
                    {
                        eye.enabled = true;
                    }
                    else
                    {
                        eye.enabled = false;
                    }
                }
                break;
            case EyeState.Ajar:
                foreach (Image eye in UIEyes)
                {
                    if (eye.name.CompareTo(Ajar) == 0)
                    {
                        eye.enabled = true;
                    }
                    else
                    {
                        eye.enabled = false;
                    }
                }
                break;
            case EyeState.Open:
                foreach (Image eye in UIEyes)
                {
                    if (eye.name.CompareTo(Open) == 0)
                    {
                        eye.enabled = true;
                    }
                    else
                    {
                        eye.enabled = false;
                    }
                }
                break;
        }
    }
    
}
