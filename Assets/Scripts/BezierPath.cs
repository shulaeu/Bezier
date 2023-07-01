using System.Collections.Generic;
using UnityEngine;



public class BezierPath
{
    public List<Vector3> pathPoints;
    private int segments;
    public int pointCount;

    public BezierPath()
    {
        pathPoints = new List<Vector3>();
        pointCount = 20;
    }

    public void DeletePath()
    {
        pathPoints.Clear();
    }

    private Vector3 BezierPathCalculation(Vector3 p0, Vector3 p1, Vector3 p2, Vector3 p3, float t)
    {
        float tt = t * t;
        float ttt = t * tt;
        float u = 1.0f - t;
        float uu = u * u;
        float uuu = u * uu;

        Vector3 b = uuu * p0;
        b += 3.0f * uu * t * p1;
        b += 3.0f * u * tt * p2;
        b += ttt * p3;

        return b;
    }

    public void CreateCurve(IBezierCoords controlPoints, int count)
    {
        segments = count;
        
        Vector3 p0 = controlPoints.StartValue;
        Vector3 p1 = controlPoints.TopValue;
        Vector3 p2 = controlPoints.DownValue;
        Vector3 p3 = controlPoints.EndValue;
           
        pathPoints.Add(BezierPathCalculation(p0, p1, p2, p3, 0.0f));
          
        for (var p = 0; p < pointCount / segments; p++)
        {
            float t = 1.0f / (pointCount / segments) * p;
            Vector3 point = BezierPathCalculation(p0, p1, p2, p3, t);
            pathPoints.Add(point);
        }
        
    }
}