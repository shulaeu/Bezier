using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
using TMPro;
using UnityEngine.UI;

public class BezierListView : MonoBehaviour
{
    [SerializeField] private UIPoint uiPointView;
    [SerializeField] private bool isSaveTopLayerPrefs;

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
            count = curvescript.transform.childCount;
        }
        return count;
    }

    private void Update()
    {
            Transform child = transform.GetChild(uiPointView.Index);
            if (child.TryGetComponent(out BezierCurveScript curveScript))
            {
                curveScript.SetStartPointPosition(uiPointView.Position, uiPointView.Type);
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
    private void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            //Debug.Log("count" +curveScripts.Count);
            Transform child = transform.GetChild(i);
            if (child.TryGetComponent(out BezierCurveScript curveScript))
            {
                string jsonData = PlayerPrefs.GetString($"{i}jsonData");
                curveScript.SetupStartData(jsonData);
                curveScript.Init();
            }
            //Debug.Log("json1" $"{i} jsonData");
        }
    }
}
