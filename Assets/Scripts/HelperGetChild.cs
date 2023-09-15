using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.Mathematics;
using static UnityEngine.Random;



public class HelperGetChild : BezierListView
//public class HelperGetChild : MonoBehaviour
{
    public List<string> GetChildList()
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

    public int GetChildCount(int index)
    {
        var count = 0;

        if (transform.GetChild(index).TryGetComponent(out BezierCurveScript curvescript))
        {
            count = curvescript.startCoords.Count;
        }
        return count;
    }
}

//Transform[] Childrens = GetComponentsInChildren<Transform>();
//foreach (Transform children in Childrens)
//    if (children.gameObject.name == "Gun1")
//    {
//        // Do something
//        break;
//    }