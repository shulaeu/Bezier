using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;
using static UnityEngine.Random;



public static class HelperGetChild
{
    private static Transform transform;

    public static void SetupTransform(Transform transform)
    {
        HelperGetChild.transform = transform;
    }
    public static List<string> GetChildList()
    {
        List<string> result = new List<string>();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.TryGetComponent(out BezierCurveScript curvescript))
            {
                result.Add(child.name);
            }
        }
        return result;
    }

    public static int GetChildCount(int index)
    {
        var count = 0;

        if (transform.GetChild(index).TryGetComponent(out BezierCurveScript curvescript))
        {
            count = curvescript.startCoords.Count;
        }
        return count;
    }
}