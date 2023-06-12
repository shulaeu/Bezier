using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;
using DefaultNamespace.ScriptableObjects;
using Unity.Mathematics;

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
            GameObject obj = Instantiate(coordsData.Prefab, coordsData.Coords[i], Quaternion.identity, transform);
            objects.Add(obj);
        }

        UpdatePath();
        for (var i = 1; i < path.pointCount; i++)
        {
            CreateCube(path.pathPoints[i]);
        }
    }

    private void CreateCube(Vector3 end)
    {
        Instantiate(coordsData.Prefab, end, quaternion.identity, transform);
    }

    private void UpdatePath()
    {
        var controlPoints = new List<Vector3>();
        for (var i = 0; i < objects.Count; i++)
        {
            if (objects[i] == null)
            {
                continue;
            }

            Vector3 position = objects[i].transform.position;
            controlPoints.Add(position);
        }

        path.DeletePath();
        path.CreateCurve(controlPoints);
    }
}