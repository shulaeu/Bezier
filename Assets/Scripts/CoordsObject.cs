using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coords", menuName = "Coordinates")]

public class CoordsObject : ScriptableObject
{
    [SerializeField] private List<BezierCoords> bezierCoords;
    [SerializeField] private GameObject prefab;
    [SerializeField] private GameObject prefabStart;
    [SerializeField] private GameObject prefabEnd;
    [SerializeField] private GameObject prefabTop;
    [SerializeField] private GameObject prefabDown;

    public List<BezierCoords> BezierCoords => bezierCoords;
    public GameObject Prefab => prefab;
    public GameObject StartPrefab => prefabStart;
    public GameObject EndPrefab => prefabEnd;
    public GameObject TopPrefab => prefabTop;
    public GameObject DownPrefab => prefabDown;
}