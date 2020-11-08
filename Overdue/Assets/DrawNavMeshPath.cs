using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawNavMeshPath : MonoBehaviour
{
    public static Vector3[] path = null;
    public static bool isChasingPlayer = false;


    void Start()
    {
    }

    void Update()
    {
        if (path != null)
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
