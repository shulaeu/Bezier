using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
using static UnityEngine.Random;


public class BezierCurveScript : MonoBehaviour
{

    [SerializeField] private int pointsAmount = 20;
    //[SerializeField] private int pointsAmount = Random.Range(1,100);
    [SerializeField] private CoordsObject coordsData;

    private readonly List<GameObject> objects = new List<GameObject>();
    private List<Points> points = new List<Points>();
    private List<RunTimeCoords> _runTimeCoordsList = new List<RunTimeCoords>();
    private BezierPath path;

    private void Start()
    {
        path = new BezierPath(pointsAmount);
        InitCoord();
        UpdatePath();
        for (var i = 1; i < path.pointCount; i++)
        {
            CreatePathGameObject(path.pathPoints[i]);
        }
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
            Vector3 startValue = coordsData.BezierCoords[i].StartValue;
            GameObject start = Instantiate(coordsData.StartPrefab, startValue, Quaternion.identity, transform);

            Vector3 endValue = coordsData.BezierCoords[i].EndValue;
            GameObject end = Instantiate(coordsData.EndPrefab, endValue, Quaternion.identity, transform);

            Vector3 topValue = coordsData.BezierCoords[i].TopValue;
            GameObject top = Instantiate(coordsData.TopPrefab, topValue, Quaternion.identity, transform);

            Vector3 downValue = coordsData.BezierCoords[i].DownValue;
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