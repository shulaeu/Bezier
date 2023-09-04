using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class UIEventHelper
{
    private static event Action<int> onDropdownShapeChange;
   
    private static event Action<int> onDropdownItemChange;

    private static event Action<int> onDropdownCoordsChange;

    private static event Action onInitUI;

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

    public static void SubscribeOnDropdownCoordsChange(Action<int> action)
    {
        onDropdownCoordsChange += action;
    }

    public static void InvokeDropdownCoordsChange(int index)
    {
        onDropdownCoordsChange?.Invoke(index);
    }
}
