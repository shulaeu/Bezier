using System;
using UnityEngine;

[Serializable]
public class RunTimeCoords : IBezierCoords
{
    [SerializeField] private Vector3 startValue;
    [SerializeField] private Vector3 endValue;
    [SerializeField] private Vector3 topValue;
    [SerializeField] private Vector3 downValue;

    public Vector3 StartValue => startValue;
    public Vector3 EndValue => endValue;
    public Vector3 TopValue => topValue;
    public Vector3 DownValue => downValue;

    public RunTimeCoords(Vector3 startValue, Vector3 endValue, Vector3 topValue, Vector3 downValue)
    {
        this.startValue = startValue;
        this.endValue = endValue;
        this.topValue = topValue;
        this.downValue = downValue;
    }
}

