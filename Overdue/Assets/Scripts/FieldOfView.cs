using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using UnityEngine.Experimental.Rendering;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEditor.Experimental.SceneManagement;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.Universal;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask; 
    private Mesh mesh;
    Vector3 origin;
    private float startingAngle;
    private float fov;
    private float viewDistance = 0f;

    private Light2D lt;


    // Start is called before the first frame update
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
        fov = 90f;
        startingAngle = 0f;
        lt = GetComponent<Light2D>();
        lt.pointLightInnerAngle = this.fov;
        lt.pointLightOuterAngle = this.fov;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        //Debug.Log("Origin " + origin);
        //Debug.Log("Angle: " + startingAngle);
        int rayCount = 50;
        float angle = this.startingAngle;
        float angleIncrease = fov / rayCount;
        

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycastHit2D) // Hit
                vertex = raycastHit2D.point;
            else // No hit
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            vertices[vertexIndex] = vertex;

            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            angle -= angleIncrease;
            vertexIndex++;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.RecalculateBounds();

        lt.transform.position = origin;
        lt.transform.rotation = Quaternion.Euler(0, 0, startingAngle);
    }

    public void SetOrigin (Vector3 origin)
    {
        this.origin = origin + new Vector3(0,0,0);
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        this.startingAngle = UtilsClass.GetAngleFromVectorFloat(aimDirection) - fov ;
    }
    
    public void SetViewDistance(float distance)
    {
        this.viewDistance = distance;
    }
}

