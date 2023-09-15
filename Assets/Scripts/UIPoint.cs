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
    [SerializeField] private TMP_Dropdown dropdownItems;

    [SerializeField] private Slider xSlider;
    [SerializeField] private Slider ySlider;
    [SerializeField] private Slider zSlider;

    [SerializeField] private BezierListView bezierListView;

    private Vector3 position;
    private float preX, preY, preZ;

    //public Action<int> onDropdownShapeChange;

    private void Awake()
    {
        UIEventHelper.SubscribeOnInitUI(Init);
    }

    public void Init()
    {
        dropdownItems.onValueChanged.AddListener(newItem =>
        {
            UIEventHelper.InvokeDropdownItemChange(newItem);
        });

        dropdownCoords.onValueChanged.AddListener(newItem =>
        {
            UIEventHelper.InvokeDropdownCoordsChange((CoordType) newItem);
        });

        dropdownShapes.onValueChanged.AddListener(index =>
        {
            dropdownItems.value = 0;
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



        dropdownShapes.options.Clear();

        List<string> names = bezierListView.GetChildList();

        foreach (string childName in names)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(childName);
            dropdownShapes.options.Add(option);
        }
        dropdownShapes.onValueChanged.AddListener(OnScriptsChanged);
        OnScriptsChanged(0);
    }

    private void OnScriptsChanged(int index)
    {
        dropdownItems.options.Clear();
        int itemCount = bezierListView.GetChildCount(index);

        for (int i = 0; i < itemCount; i++)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(i.ToString());
            //Debug.Log("i" + i);
            dropdownItems.options.Add(option);
        }
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
