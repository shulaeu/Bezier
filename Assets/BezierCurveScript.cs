using UnityEngine;
using System.Collections.Generic;
using Unity.Mathematics;

public class BezierCurveScript : MonoBehaviour
{
    private readonly BezierPath path = new();

    [SerializeField] private CoordsObject coords;
    [SerializeField] private GameObject prefab;
    [SerializeField] private List<GameObject> objects;

    [SerializeField] private CoordsObject prefCoords;
    [SerializeField] private GameObject prefab2;
    [SerializeField] private List<GameObject> prefs;
        
    private void Start()
    {
         if (prefs.Count !> 1 || objects.Count! > 1)
         {
            return;
         }

        for (var i = 0; i < objects.Count; i++)
        {
            objects[i].transform.position = coords.Coords[i];
        }

        for (var i = 0; i < prefs.Count; i++)
        {
            prefs[i].transform.position = prefCoords.Coords[i];
        }

        for (var i = 0; i < prefs.Count; i++)
        {
            prefs[i].transform.position = prefCoords.Coords[i];
        }

        for (var i = 0; i < objects.Count; i++)
        {
            objects[i].transform.position = coords.Coords[i];
        }

        UpdatePath();
        for (var i = 1; i < path.pointCount; i++)
        {
            CreateCube(path.pathPoints[i]);
        }
    }

    private void CreateCube(Vector3 end)
    {
        Instantiate(prefab, end, quaternion.identity, transform);
        Instantiate(prefab2, end, quaternion.identity, transform);
    }

    private void UpdatePath()
    {
        var controlPoints = new List<Vector3>();
        for (var i = 0; i < prefs.Count; i++)
        {
            if (prefs[i] == null)
            {
                continue;
            }

            Vector3 position = prefs[i].transform.position;
            controlPoints.Add(position);
        }

        path.DeletePath();
        path.CreateCurve(controlPoints);
    }
}