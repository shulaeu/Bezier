using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Mathematics;
using static UnityEngine.Random;
using TMPro;
using UnityEngine.UI;

public class UIPoint : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    [SerializeField] private Slider xSlider;
    [SerializeField] private Slider ySlider;
    [SerializeField] private Slider zSlider;

    public Vector3 Position { get; private set; }

    public CoordType Type { get; private set; }

    private float preX, preY, preZ;


    private void Update()
    {
        if (Math.Abs(Position.x - preX) > 0.00001f)
        {
            Position = new Vector3(preX, Position.y, Position.z);
        }
        else
        {
            xSlider.value = 0;
            preX = 0;
            Position = Vector3.zero;
        }

        if (Math.Abs(Position.y - preY) > 0.00001f)
        {
            Position = new Vector3(Position.x, preY, Position.z);
        }
        else
        {
            ySlider.value = 0;
            preY = 0;
            Position = Vector3.zero;
        }

        if (Math.Abs(Position.z - preZ) > 0.00001f)
        {
            Position = new Vector3(Position.x, Position.y, preZ);
        }
        else
        {
            zSlider.value = 0;
            preZ = 0;
            Position = Vector3.zero;
        }
    }
    void Start()
    {
        //Debug.Log("Start");
        dropdown.onValueChanged.AddListener(newItem =>
        {
            Type = (CoordType)newItem;
        });

        xSlider.onValueChanged.AddListener(xValue =>
        {
            preX = xValue;
        });

        ySlider.onValueChanged.AddListener(yValue =>
        {
            preY = yValue;
        });

        zSlider.onValueChanged.AddListener(zValue =>
        {
            preZ = zValue;
        });
    }
}
