using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using System;


[Serializable]
public class BezierCoords : IBezierCoords
{
    [SerializeField] private Vector3 startValue;
    [SerializeField] private Vector3 endValue;
    [SerializeField] private Vector3 topValue;
    [SerializeField] private Vector3 downValue;
    public Vector3 StartValue => startValue;
    public Vector3 EndValue => endValue;
    public Vector3 TopValue => topValue;
    public Vector3 DownValue => downValue;


    public BezierCoords(IBezierCoords coords)
    {
        this.startValue = StartValue;
        this.endValue = EndValue;
        this.topValue = TopValue;
        this.downValue = DownValue;
    }
}