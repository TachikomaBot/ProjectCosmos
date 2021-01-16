﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawCircle : MonoBehaviour
{
    public int radius;
    public float lineWidth;
    public Material lineMat;

    // Start is called before the first frame update
    void Start()
    {
        var go1 = new GameObject { name = "Circle" };
        go1.DrawCircle(radius, lineWidth, lineMat);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public static class GameObjectEx
{
    public static void DrawCircle(this GameObject container, float radius, float lineWidth, Material lineMat)
    {
        var segments = 360;
        var line = container.AddComponent<LineRenderer>();
        line.useWorldSpace = false;
        line.startWidth = lineWidth;
        line.endWidth = lineWidth;
        line.positionCount = segments + 1;

        line.material = lineMat;

        var pointCount = segments + 1; // add extra point to make startpoint and endpoint the same to close the circle
        var points = new Vector3[pointCount];

        for (int i = 0; i < pointCount; i++)
        {
            var rad = Mathf.Deg2Rad * (i * 360f / segments);
            points[i] = new Vector3(Mathf.Sin(rad) * radius, 0, Mathf.Cos(rad) * radius);
        }

        line.SetPositions(points);
    }
}