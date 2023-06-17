using System.Collections;
using System.Collections.Generic;
using DefaultNamespace.ScriptableObjects;
using UnityEngine;


[CreateAssetMenu(fileName = "Coords", menuName = "Coordinates")]

public class CoordsObject : ScriptableObject
{
    //[SerializeField] private List<CustomCoord> coords;
    [SerializeField] private List<BezierCoords> bezierCoords;
    [SerializeField] private GameObject prefab;
    

    public List<CustomCoord> Coords => coords;
    public List<BezierCoords> BezierCoords => bezierCoords;
    public GameObject Prefab => prefab; // making this object readonly by alpha expression
}

