using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownBezier : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private TMP_Dropdown itemsDropdown;
    [SerializeField] private BezierListView bezierListView;

    private void Start()
    {
        dropdown.options.Clear();

        List<string> names = bezierListView.GetChildList();

        foreach (string childName in names)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(childName);
            dropdown.options.Add(option);
        }
        dropdown.onValueChanged.AddListener(OnScriptsChanged);
        OnScriptsChanged(0);
    }

    private void OnScriptsChanged(int index)
    {
        itemsDropdown.options.Clear();
        int itemCount = bezierListView.GetChildCount(index);
        
        for (int i = 0; i < itemCount; i++)
        {
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(i.ToString());
            //Debug.Log("i" + i);
            itemsDropdown.options.Add(option);
        }
    }
}