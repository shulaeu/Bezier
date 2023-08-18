using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropDownBezier : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;
    [SerializeField] private BezierListView bezierListView;

    void Start()
    {
        dropdown.options.Clear();
        List<string> names = bezierListView.GetChildList();
        foreach (string childName in names)
        {
            //dropdown.options.Add(new TMP_Dropdown.OptionData(childName));
            TMP_Dropdown.OptionData option = new TMP_Dropdown.OptionData(childName);
            dropdown.options.Add(option);
        }
    }
}
