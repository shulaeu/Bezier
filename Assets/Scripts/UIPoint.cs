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
    [SerializeField] private TMP_Dropdown DropdownItems;

    [SerializeField] private Slider xSlider;
    [SerializeField] private Slider ySlider;
    [SerializeField] private Slider zSlider;

    private Vector3 position;
    //public int Index { get; private set; }
    //public CoordType Type { get; private set; }
    //public int ItemIndex { get; private set; }

    private float preX, preY, preZ;

    //public Action<int> onDropdownShapeChange;

    private void Awake()
    {
        UIEventHelper.SubscribeOnInitUI(Init);
    }

    public void Init()
    {
        DropdownItems.onValueChanged.AddListener(newItem =>
        {
            UIEventHelper.InvokeDropdownItemChange(newItem);
        });

        dropdownCoords.onValueChanged.AddListener(newItem =>
        {
            UIEventHelper.InvokeDropdownCoordsChange((CoordType) newItem);
        });

        dropdownShapes.onValueChanged.AddListener(index =>
        {
            DropdownItems.value = 0;
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
        if (Math.Abs(position.x - preX) > 0.00001f)
        {
            position = new Vector3(preX, position.y, position.z);
            UIEventHelper.InvokeChangePosition(position);
            //Debug.Log("preX" + preX);
        }
        else
        {
            xSlider.value = 0;
        }

        if (Math.Abs(position.y - preY) > 0.00001f)
        {
            position = new Vector3(position.x, preY, position.z);
            UIEventHelper.InvokeChangePosition(position);
        }
        else
        {
            ySlider.value = 0;
        }

        if (Math.Abs(position.z - preZ) > 0.00001f)
        {
            position = new Vector3(position.x, position.y, preZ);
            UIEventHelper.InvokeChangePosition(position);
        }
        else
        {
            zSlider.value = 0;
        }
    }
}
