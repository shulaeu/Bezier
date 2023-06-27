using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
using DefaultNamespace.ScriptableObjects;

public class BezierCurveScript : MonoBehaviour
{
    private readonly BezierPath path = new();

    [SerializeField] private Material startMat;
    [SerializeField] private Material endMat;
    [SerializeField] private Material controlMat;
    [SerializeField] private CoordsObject coordsData;
    private readonly List<GameObject> objects = new List<GameObject>();

    private GameObject tempStart;
    private GameObject tempEnd;
    private GameObject tempTop;
    private GameObject tempDown;

    private void Start()
    {
        
        InitCoord();
        UpdatePath();
        for (var i = 1; i < path.pointCount; i++)
        {
            var obj = new RunTimeCoords
                (tempStart.transform.localPosition,
                tempEnd.transform.localPosition,
                tempTop.transform.localPosition,
                tempDown.transform.localPosition);
                path.CreateCurve(obj,1);
        }
    }

    private void Update()
    {
        path.DeletePath();
        for (var i = 1; i < path.pointCount; i++)
        {
            path.CreateCurve(new RunTimeCoords(), 1);
        }
    }

    private void InitCoord()
    {
    for (var i=0; i<coordsData.BezierCoords.Count; i++)
        {
            Vector3 startValue = coordsData.BezierCoords[i].StartValue;
            tempStart = Instantiate(coordsData.StartPrefab, startValue, Quaternion.identity, transform);
           
            Vector3 topValue = coordsData.BezierCoords[i].TopValue;
            tempTop = Instantiate(coordsData.TopPrefab, topValue, Quaternion.identity, transform);
            
            Vector3 downValue = coordsData.BezierCoords[i].DownValue;
            tempDown = Instantiate(coordsData.DownPrefab, downValue, Quaternion.identity, transform);
           
            Vector3 endValue = coordsData.BezierCoords[i].EndValue;
            tempEnd = Instantiate(coordsData.EndPrefab, endValue, Quaternion.identity, transform);
        }
    }

    private void CreatePathGameObject(Vector3 end)
    {
        GameObject obj = Instantiate(coordsData.Prefab, end, quaternion.identity, transform);
        objects.Add(obj);
    }

    private void UpdatePath()
    {
        path.DeletePath();
        for (var i = 0; i < coordsData.BezierCoords.Count; i++)
        {
            path.CreateCurve(coordsData.BezierCoords[i], coordsData.BezierCoords.Count);
        }
    }
}