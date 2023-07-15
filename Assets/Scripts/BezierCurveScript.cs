using System;
using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
using static UnityEngine.Random;


public class BezierCurveScript : MonoBehaviour
{

    [SerializeField] private int pointsAmount = 20;
    [SerializeField] private CoordsObject coordsData;

    private readonly List<GameObject> objects = new List<GameObject>();
    private List<Points> points = new List<Points>();
    private readonly List<RunTimeCoords> _runTimeCoordsList = new List<RunTimeCoords>();
    //private readonly List<RunTimeCoords<String>> _runTimeCoordsList = new List<RunTimeCoords<String>>();
    private BezierPath path;

    private List<IBezierCoords> startCoords;

    private void Start()
    {

        SetupStartData();
        path = new BezierPath(pointsAmount);
        InitCoord();
        UpdatePath();
        for (var i = 1; i < path.pointCount; i++)
        {
            CreatePathGameObject(path.pathPoints[i]);
        }
    }

    private void SetupStartData()
    {
        string data = PlayerPrefs.GetString("jsonData");
        if (data == string.Empty)
        {
            startCoords = new List<IBezierCoords>(coordsData.BezierCoords);
            return;
        }
        

        try
        {
            var saveData = JsonUtility.FromJson<SaveJsonData>(data);
            startCoords = new List<IBezierCoords>(saveData._runTimeCoordsList);
        }
        catch (Exception _)
        {
            //Console.WriteLine(e);
            //throw;
            startCoords = new List<IBezierCoords>(coordsData.BezierCoords);
        }
    }


    private void OnDestroy()
    {
        SaveJsonData data = new SaveJsonData(_runTimeCoordsList);
        string jsonData = JsonUtility.ToJson(data);
        PlayerPrefs.SetString("jsonData",jsonData);
    }

    private void UpdatePath()
    {
        path.DeletePath();
        for (var i = 0; i < coordsData.BezierCoords.Count; i++)
        {
            path.CreateCurve(coordsData.BezierCoords[i], coordsData.BezierCoords.Count);
        }
    }

    private void Update()
    {
        RecreateCurve();
        UpdatePoints();
    }

    private void RecreateCurve()
    {
        path.DeletePath();
        _runTimeCoordsList.Clear();

        for (int j = 0; j < coordsData.BezierCoords.Count; j++)
        {
            Vector3 start = points[j].GetPosition(CoordType.Start);
            Vector3 end = points[j].GetPosition(CoordType.End);
            Vector3 top = points[j].GetPosition(CoordType.Top);
            Vector3 down = points[j].GetPosition(CoordType.Down);
            var obj = new RunTimeCoords(start, end, top, down);
            _runTimeCoordsList.Add(obj);
            path.CreateCurve(obj, coordsData.BezierCoords.Count);
        }
    }

    private void UpdatePoints()
    {
        for (var i = 1; i < path.pointCount; i++)
        {
            int objI = i - 1;
            objects[objI].transform.position = path.pathPoints[objI];
        }
    }

    private void InitCoord()
    {
        for (var i = 0; i < coordsData.BezierCoords.Count; i++)
        {
            Vector3 startValue = startCoords[i].StartValue;
            GameObject start = Instantiate(coordsData.StartPrefab, startValue, Quaternion.identity, transform);

            Vector3 endValue = startCoords[i].EndValue;
            GameObject end = Instantiate(coordsData.EndPrefab, endValue, Quaternion.identity, transform);

            Vector3 topValue = startCoords[i].TopValue;
            GameObject top = Instantiate(coordsData.TopPrefab, topValue, Quaternion.identity, transform);

            Vector3 downValue = startCoords[i].DownValue;
            GameObject down = Instantiate(coordsData.DownPrefab, downValue, Quaternion.identity, transform);
            points.Add(new Points(start, end, top, down));
            
        }
    }

    private void CreatePathGameObject(Vector3 end)
    {
        GameObject obj = Instantiate(coordsData.Prefab, end, quaternion.identity, transform);
        objects.Add(obj);
    }
}