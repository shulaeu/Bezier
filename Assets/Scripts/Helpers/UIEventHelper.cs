using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class UIEventHelper
{
    private static event Action<bool> onToggleJoystick;

    private static event Action<int> onDropdownShapeChange;
   
    private static event Action<int> onDropdownItemChange;

    private static event Action<CoordType> onDropdownCoordsChange;

    private static event Action<Vector3> onChangePosition;

    private static event Action onInitUI;

    public static void SubscribeOnToggleJoystick(Action<bool> action)
    {
        onToggleJoystick += action;
    }
    public static void InvokeToggleJoystick(bool value)
    {
        onToggleJoystick?.Invoke(value);
    }
    public static void SubscribeOnChangePosition(Action<Vector3> action)
    {
        onChangePosition += action;
    }
    public static void InvokeChangePosition(Vector3 position)
    {
        onChangePosition?.Invoke(position);
    }

    public static void SubscribeOnInitUI (Action action)
    {
        onInitUI += action;
    }
    public static void InvokeInitUI()
    {
        onInitUI?.Invoke();
    }

    public static void SubscribeOnDropdownShapeChange(Action<int> action)
    {
        onDropdownShapeChange += action;
    }
    public static void InvokeDropdownShapeChange(int index)
    {
        onDropdownShapeChange?.Invoke(index);
    }

    public static void SubscribeOnDropdownItemChange(Action<int> action)
    {
        onDropdownItemChange += action;
    }
    public static void InvokeDropdownItemChange(int index)
    {
        onDropdownItemChange?.Invoke(index);
    }

    public static void SubscribeOnDropdownCoordsChange(Action<CoordType> action)
    {
        onDropdownCoordsChange += action;
    }
    public static void InvokeDropdownCoordsChange(CoordType coordType)
    {
        onDropdownCoordsChange?.Invoke(coordType);
    }
}
