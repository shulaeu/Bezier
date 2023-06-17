using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
using DefaultNamespace.ScriptableObjects;

public class BezierCurveScript : MonoBehaviour
{
    private readonly BezierPath path = new();

    [SerializeField] private CoordsObject coordsData;
    private readonly List<GameObject> objects = new List<GameObject>();
    //public CoordsObject coords;
    //[SerializeField] private CoordsObject coords;
    //[SerializeField] private GameObject prefab;

    private void Start()
    {
        for (var i = 0; i < coordsData.Coords.Count; i++)
        {
            GameObject obj = Instantiate(coordsData.Prefab, coordsData.Coords[i].Value, Quaternion.identity, transform);
            objects.Add(obj);
        }

        UpdatePath();
        for (var i = 1; i < path.pointCount; i++)
        {
            CreateCube(path.pathPoints[i]);
        }
    }

    private void InitCoord()
    {
    for (var i=0; i<coordsData.BezierCoords.Count; i++)
        {
            Vector3 startValue = coordsData.BezierCoords[i].StartValue;
            Instantiate(coordsData.Prefab, startValue, Quaternion.identity, transform);
            Vector3 topValue = coordsData.BezierCoords[i].TopValue;
            Instantiate(coordsData.Prefab, topValue, Quaternion.identity, transform);
            Vector3 downValue = coordsData.BezierCoords[i].DownValue;
            Instantiate(coordsData.Prefab, downValue, Quaternion.identity, transform);
            Vector3 endValue = coordsData.BezierCoords[i].EndValue;
            Instantiate(coordsData.Prefab, endValue, Quaternion.identity, transform);
        }
    }

    private void CreateCube(Vector3 end)
    {
        Instantiate(coordsData.Prefab, end, quaternion.identity, transform);
    }

    private void UpdatePath()
    {
        path.DeletePath();
        for (var i = 0; i < coordsData.BezierCoords.Count; i++)
        {
            path.CreateCurve(coordsData.BezierCoords[i], coordsData.BezierCoords.Count);
        }
        //var controlPoints = new List<Vector3>();
        //for (var i = 0; i < objects.Count; i++)
        //{
        //    if (objects[i] == null)
        //    {
        //        continue;
        //    }

        //    Vector3 position = objects[i].transform.position;
        //    controlPoints.Add(position);
        //}

        //for (var i = 0; i < coordsData.BezierCoords.Count; i++)
        //{
        //    path.DeletePath();
        //    path.CreateCurve(coordsData.BezierCoords[i],coordsData.BezierCoords.Count);
        //    //path.CreateCurve(CoordsObject.BezierCoords[i], coordsData.BezierCoords.Count);
        //}
    }
}