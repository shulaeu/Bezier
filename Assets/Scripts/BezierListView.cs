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

    private void Awake()
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
        uiPointView.Init();
        //gameObject.SetActive(falce);
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
        Debug.Log("GetChildCount1");
        if (transform.GetChild(index).TryGetComponent(out BezierCurveScript curvescript))
        {
            Debug.Log("GetChildCount2");
            //count = curvescript.transform.childCount;
            count = curvescript.startCoords.Count;
        }
        return count;
    }
}
