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

    private BezierPath path;

    public List<IBezierCoords> startCoords { get; private set; } = new List<IBezierCoords>();

    public List<RunTimeCoords> RunTimeCoordsList()
    {
        return _runTimeCoordsList;
    }

    public void Init()
    {
        //Debug.Log("Init");
        path = new BezierPath(pointsAmount);
        InitCoord();
        UpdatePath();
        for (int i = 1; i < path.pointCount; i++)
        {
            CreatePathGameObject(path.pathPoints[i]);
        }
    }

    private void Update()
    {
        //Debug.Log("Update");
        RecreateCurve();
        UpdatePoints();
    }

    private void OnDestroy()
    {
        if (_runTimeCoordsList.Count > 0)
        {
            SaveJsonData data = new SaveJsonData(_runTimeCoordsList);
            string jsonData = JsonUtility.ToJson(data);
            PlayerPrefs.SetString("jsonData", jsonData);
        }
    }

    public void SetupStartData(string jsonData)
    {
        if (jsonData == string.Empty)
        {
            InitDefaultCoords();
            return;
        }

        try
        {
            SaveJsonData saveData = JsonUtility.FromJson<SaveJsonData>(jsonData);
            startCoords = new List<IBezierCoords>(saveData._runTimeCoordsList);
            InitDefaultCoords();
        }
        catch (Exception _)
        {
            InitDefaultCoords();
        }
    }

    private void InitDefaultCoords()
    {
        if (startCoords.Count == 0)
        {
            startCoords = new List<IBezierCoords>(coordsData.BezierCoords);
        }
    }

    private void UpdatePath()
    {
        path.DeletePath();
        for (var i = 0; i < startCoords.Count; i++)
        {
            path.CreateCurve(startCoords[i], startCoords.Count);
        }
    }

    private void RecreateCurve()
    {
        //Debug.Log("Recreate");
        path.DeletePath();
        _runTimeCoordsList.Clear();

        for (int i = 0; i < startCoords.Count; i++)
        {
            Vector3 start = points[i].GetPosition(CoordType.Start);
            Vector3 end = points[i].GetPosition(CoordType.End);
            Vector3 top = points[i].GetPosition(CoordType.Top);
            Vector3 down = points[i].GetPosition(CoordType.Down);
            var obj = new RunTimeCoords(start, end, top, down);
            _runTimeCoordsList.Add(obj);
            //Debug.Log("ObjData" +obj);
            path.CreateCurve(obj, startCoords.Count);
        }
    }

    private void UpdatePoints()
    {
        //Debug.Log("UpdatePoints");      
        for (var i = 1; i < path.pointCount; i++)
        //for (var i = 1; i < points.Count; i++)
        {
            int objI = i - 1;
            objects[objI].transform.position = path.pathPoints[objI];
            //objects[objI].transform.position = points[objI];
        }
    }

    private void InitCoord()
    {
        //Debug.Log("startCoords: "+startCoords.Count);
        for (var i = 0; i < startCoords.Count; i++)
        {
            //Debug.Log($"startCoords: { startCoords.Count}");
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
        GameObject obj = Instantiate(coordsData.Prefab, end, Quaternion.identity, transform);
        objects.Add(obj);
    }

    public void SetStartPointPosition(Vector3 position, CoordType type)
    {
        for (int i = 0; i < points.Count; i++)
        {
            points[i].SetPosition(position, type);
        }
    }
}