using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Coords", menuName = "Coordinates")]

public class CoordsObject : ScriptableObject
{
    [SerializeField] private List<Vector3> coords;

    public List<Vector3> Coords => coords;
}

public class CoordsObjectPrefs : ScriptableObject
{
    [SerializeField] private List<Vector3> prefCoords;

    public List<Vector3> PrefCoords => prefCoords;
}

