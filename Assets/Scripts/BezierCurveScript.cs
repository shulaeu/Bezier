using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;


public class BezierCurveScript : MonoBehaviour
{
    private readonly BezierPath path = new();

    [SerializeField] private CoordsObject coordsData;
    private readonly List<GameObject> objects = new List<GameObject>();
    private List<Points> points = new List<Points>();

    //[SerializeField] private Material startMat;
    //[SerializeField] private Material endMat;
    //[SerializeField] private Material controlMat;

    private List<GameObject> tempStart = new List<GameObject>();
    private List<GameObject> tempEnd = new List<GameObject>();
    private List<GameObject> tempTop = new List<GameObject>();
    private List<GameObject> tempDown = new List<GameObject>();

    //private GameObject tempStart;
    //private GameObject tempEnd;
    //private GameObject tempTop;
    //private GameObject tempDown;

    private void Start()
    {
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
        for (var i = 1; i < path.pointCount; i++)
        {
            for (var j = 0; j < coordsData.BezierCoords.Count; j++)
            {
                Vector3 start = points[j].GetPosition(CoordType.Start);
                Vector3 end = points[j].GetPosition(CoordType.End);
                Vector3 top = points[j].GetPosition(CoordType.Top);
                Vector3 down = points[j].GetPosition(CoordType.Down);
                RunTimeCoords obj = new RunTimeCoords(start, end, top, down);
                path.CreateCurve(obj, coordsData.BezierCoords.Count);
            }
            
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
    for (var i=0; i<coordsData.BezierCoords.Count; i++)
        {
            Vector3 startValue = coordsData.BezierCoords[i].StartValue;
            tempStart[i] = Instantiate(coordsData.StartPrefab, startValue, Quaternion.identity, transform);

            Vector3 endValue = coordsData.BezierCoords[i].EndValue;
            tempEnd[i] = Instantiate(coordsData.EndPrefab, endValue, Quaternion.identity, transform);

            Vector3 topValue = coordsData.BezierCoords[i].TopValue;
            tempTop[i] = Instantiate(coordsData.TopPrefab, topValue, Quaternion.identity, transform);
            
            Vector3 downValue = coordsData.BezierCoords[i].DownValue;
            tempDown[i] = Instantiate(coordsData.DownPrefab, downValue, Quaternion.identity, transform);
        }
    }

    private void CreatePathGameObject(Vector3 end)
    {
        GameObject obj = Instantiate(coordsData.Prefab, end, quaternion.identity, transform);
        objects.Add(obj);
    }
}