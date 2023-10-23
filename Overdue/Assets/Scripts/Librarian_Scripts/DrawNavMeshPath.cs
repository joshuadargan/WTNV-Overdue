using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawNavMeshPath : MonoBehaviour
{
    public Vector3[] path { get; set; } = null;
    public bool isChasingPlayer { get; set; } = false;


    void Start()
    {
    }

    void Update()
    {
        if (path != null && CheatCodeInput.debugMode)
        {
            for (int i = 0; i < path.Length - 1; i++)
            {
                if (isChasingPlayer)
                {
                    Debug.DrawLine(path[i], path[i + 1], Color.red, 5);
                }
                else
                {
                    Debug.DrawLine(path[i], path[i + 1], Color.blue, 5);
                }
               
            }
            path = null;
        }
    }
}
