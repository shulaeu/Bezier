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
    //public CoordsObject coords;
    //[SerializeField] private CoordsObject coords;
    //[SerializeField] private GameObject prefab;

    private void Start()
    {
        //for (var i = 0; i < coordsData.Coords.Count; i++)
        //{
        //    GameObject obj = Instantiate(coordsData.Prefab, coordsData.Coords[i].Value, Quaternion.identity, transform);
        //    objects.Add(obj);
        //}

        InitCoord();
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
            var startObj = Instantiate(coordsData.StartPrefab, startValue, Quaternion.identity, transform);
            var startMesh = startObj.GetComponent<MeshRenderer>();
            startMesh.material = startMat;
            
            Vector3 topValue = coordsData.BezierCoords[i].TopValue;
            var topObject = Instantiate(coordsData.TopPrefab, topValue, Quaternion.identity, transform);
            var topMesh = startObj.GetComponent<MeshRenderer>();
            topMesh.material = controlMat;

            Vector3 downValue = coordsData.BezierCoords[i].DownValue;
            var downObject = Instantiate(coordsData.DownPrefab, downValue, Quaternion.identity, transform);
            var downMesh = startObj.GetComponent<MeshRenderer>();
            downMesh.material = controlMat;

            Vector3 endValue = coordsData.BezierCoords[i].EndValue;
            var endObject = Instantiate(coordsData.EndPrefab, endValue, Quaternion.identity, transform);
            var endMesh = startObj.GetComponent<MeshRenderer>();
            endMesh.material = endMat;
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