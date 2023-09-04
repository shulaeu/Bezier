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
    [SerializeField] private TMP_Dropdown dropdownCoords;
    [SerializeField] private TMP_Dropdown dropdownShapes;
    [SerializeField] private TMP_Dropdown itemsDropdown;

    [SerializeField] private Slider xSlider;
    [SerializeField] private Slider ySlider;
    [SerializeField] private Slider zSlider;

    public Vector3 Position { get; private set; }
    //public int Index { get; private set; }
    public CoordType Type { get; private set; }
    public int ItemIndex { get; private set; }

    private float preX, preY, preZ;

    //public Action<int> onDropdownShapeChange;

    private void Awake()
    {
        UIEventHelper.SubscribeOnInitUI(Init);
    }

    public void Init()
    {
        itemsDropdown.onValueChanged.AddListener(newItem =>
        {
            ItemIndex = newItem;
            //UIEventHelper.InvokeDropdownItemChange(index);
        });

        dropdownCoords.onValueChanged.AddListener(newItem =>
        {
            Type = (CoordType)newItem;
            //UIEventHelper.InvokeDropdownCoordsChange(index);
        });

        dropdownShapes.onValueChanged.AddListener(index =>
        {
            ItemIndex = 0;
            itemsDropdown.value = 0;
            //Index = index;
            UIEventHelper.InvokeDropdownShapeChange(index);
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
    private void Update()
    {
        if (Math.Abs(Position.x - preX) > 0.00001f)
        {
            Position = new Vector3(preX, Position.y, Position.z);
            //Debug.Log("preX" + preX);
        }
        else
        {
            xSlider.value = 0;
        }

        if (Math.Abs(Position.y - preY) > 0.00001f)
        {
            Position = new Vector3(Position.x, preY, Position.z);
        }
        else
        {
            ySlider.value = 0;
        }

        if (Math.Abs(Position.z - preZ) > 0.00001f)
        {
            Position = new Vector3(Position.x, Position.y, preZ);
        }
        else
        {
            zSlider.value = 0;
        }
    }
}
