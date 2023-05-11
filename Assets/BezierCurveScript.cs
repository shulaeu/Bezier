using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;

public class BezierCurveScript : MonoBehaviour
{
    private readonly BezierPath path = new();

    [SerializeField] private GameObject prefab;
    [SerializeField] private List<GameObject> objects;

    private void Start()
    {
        UpdatePath();
        for (var i = 1; i < path.pointCount; i++)
        {
            CreateCube(path.pathPoints[i]);
        }
    }

    private void CreateCube(Vector3 end)
    {
        Instantiate(prefab, end, quaternion.identity, transform);
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