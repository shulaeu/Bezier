using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Random;
using TMPro;
using UnityEngine.UI;

public class BezierListView : MonoBehaviour
{
    //[SerializeField] private List<BezierCurveScript> curveScripts;
    [SerializeField] private UIPointView uiPointView;

    private void Update()
    {
        for (int i = 0; i<curveScripts.Count; i++)
        {
            BezierCurveScript curveScript = curveScripts[i];
            curveScript.SetStartPointPosition(uiPointView.Position, uiPointView.Type);

        }
    }

    private void OnDestroy()
    {
        for (int i = 0; i < curveScripts.Count; i++)
        {
            BezierCurveScript curveScript = curveScripts[i];
            SaveJsonData data = new SaveJsonData(curveScript.RunTimeCoordsList());
            string jsonData = JsonUtility.ToJson(data);
            PlayerPrefs.SetString($"{i}jsonData", jsonData);
        }
    }
    //private void Start()
    //{
    //    for (int i = 0; i < curveScripts.Count; i++)
    //    {
    //        //Debug.Log("count" +curveScripts.Count);
    //        BezierCurveScript curveScript = curveScripts[i];
    //        string jsonData = PlayerPrefs.GetString($"{i}jsonData");
    //        //Debug.Log("json1" $"{i} jsonData");
    //        curveScript.SetupStartData(jsonData);
    //        curveScript.Init();
    //    }
    //}
}
