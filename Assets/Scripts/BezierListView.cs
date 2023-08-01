using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierListView : MonoBehaviour
{
    [SerializeField] private List<BezierCurveScript> curveScripts;

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
    private void Start()
    {
        for (int i = 0; i < curveScripts.Count; i++)
        {
            BezierCurveScript curveScript = curveScripts[i];
            string jsonData = PlayerPrefs.GetString($"{i}jsonData");
            curveScript.SetupStartData(jsonData);
        }
    }
}
