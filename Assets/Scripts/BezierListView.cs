using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
using TMPro;
using UnityEngine.UI;
using System;

public class BezierListView : MonoBehaviour
{
    //[SerializeField] private UIPoint uiPointView;
    [SerializeField] private bool isSaveTopLayerPrefs;

    private int shapeIndex;
    
    private int coordsIndex;

    private Vector3 Position;
    private CoordType Type;
    private int ItemIndex;

    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            
            Transform child = transform.GetChild(i);
            if (child.TryGetComponent(out BezierCurveScript curveScript))
            {
                string jsonData = PlayerPrefs.GetString($"{i}jsonData");
                curveScript.SetupStartData(jsonData);
                curveScript.Init();
            }
            //Debug.Log("json1" $"{i} jsonData");
        }        
        UIEventHelper.InvokeInitUI();
        UIEventHelper.SubscribeOnDropdownShapeChange(DropdownShapeChange);
        UIEventHelper.SubscribeOnDropdownItemChange(DropdownItemChange);
        UIEventHelper.SubscribeOnDropdownCoordsChange(DropdownCoordsChange);
    }

    private void DropdownShapeChange(int index)
    {
        shapeIndex = index;
    }

    private void DropdownItemChange(int index)
    {
       ItemIndex = index;
    }

    private void DropdownCoordsChange(int index)
    {
        coordsIndex = index;
    }

    private void Update()
    {
        Transform child = transform.GetChild(shapeIndex);
        if (child.TryGetComponent(out BezierCurveScript curveScript))
        {
            curveScript.SetStartPointPosition(Position, Type, ItemIndex);
        }
    }
    private void OnDestroy()
    {
        if (!isSaveTopLayerPrefs)
        {
            return;
        }

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);
            if (child.TryGetComponent(out BezierCurveScript curveScript))
            {
                SaveJsonData data = new SaveJsonData(curveScript.RunTimeCoordsList());
                string jsonData = JsonUtility.ToJson(data);
                PlayerPrefs.SetString($"{i}jsonData", jsonData);
            }
        }
    }

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
        //Debug.Log("GetChildCount1");
        //Debug.Log("indexGetChild" + index);
        if (transform.GetChild(index).TryGetComponent(out BezierCurveScript curvescript))
        {
            //Debug.Log("GetChildCount2");
            count = curvescript.startCoords.Count;
        }
        return count;
    }
}
