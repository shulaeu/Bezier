using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;

[CreateAssetMenu(fileName = "Coords", menuName = "Coordinates")]

public class CoordsObject : ScriptableObject
{
    [SerializeField] private List<Vector3> coords;
    [SerializeField] private GameObject prefab;
    

    public List<Vector3> Coords => coords;
    public GameObject Prefab => prefab; // делаем объект - readonly
}

