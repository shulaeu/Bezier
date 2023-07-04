using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;


public class BezierCurveScript : MonoBehaviour
{
    private readonly BezierPath path = new();

    [SerializeField] private CoordsObject coordsData;
    private readonly List<GameObject> objects = new List<GameObject>();
    private List<Points> points = new List<Points>();
    private List<RunTimeCoords> _runTimeCoordsList = new List<RunTimeCoords>();

    private void Start()
    {
        InitCoord();
        UpdatePath();
        for (var i = 1; i < path.pointCount; i++)
        {
            CreatePathGameObject(path.pathPoints[i]);
        }
    }

    private void OnDestroy()
    {
        coordsData.SetBezierCoords(_runTimeCoordsList);
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
        for (var i = 1; i < path.pointCount; i++)
        {
            for (int j = 0; j < coordsData.BezierCoords.Count; j++)
            { }

            Vector3 start = points[i].GetPosition(CoordType.Start);
            Vector3 end = points[i].GetPosition(CoordType.End);
            Vector3 top = points[i].GetPosition(CoordType.Top);
            Vector3 down = points[i].GetPosition(CoordType.Down);
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
            Vector3 startValue = coordsData.BezierCoords[i].StartValue;
            GameObject start = Instantiate(coordsData.StartPrefab, startValue, Quaternion.identity, transform);

            Vector3 endValue = coordsData.BezierCoords[i].EndValue;
            GameObject end = Instantiate(coordsData.EndPrefab, endValue, Quaternion.identity, transform);

            Vector3 topValue = coordsData.BezierCoords[i].TopValue;
            GameObject top = Instantiate(coordsData.TopPrefab, topValue, Quaternion.identity, transform);

            Vector3 downValue = coordsData.BezierCoords[i].DownValue;
            GameObject down = Instantiate(coordsData.DownPrefab, downValue, Quaternion.identity, transform);
        }
    }

    private void CreatePathGameObject(Vector3 end)
    {
        GameObject obj = Instantiate(coordsData.Prefab, end, quaternion.identity, transform);
        objects.Add(obj);
    }
}