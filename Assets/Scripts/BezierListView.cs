using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierListView : MonoBehaviour
{
    [SerializeField] private List<BezierCurveScript> _curvescripts;

    //private void OnDestroy()
    //{
    //    for (int i = 0; i < _curvescripts.Count; i++)
    //    {
    //          BezierCurveScript curveScript = curveScripts[i];
                //SaveJsonData data = new SaveJsonData(BezierCurveScript.RunTimeCoordsList());
                //string jsonData = JsonUtility.ToJson(data);
                //PlayerPrefs.SetString($"{i}"jsonData", jsonData);
    //    }
    //}

}
